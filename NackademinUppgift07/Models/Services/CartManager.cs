using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NackademinUppgift07.DataModels;
using NackademinUppgift07.Utility;

namespace NackademinUppgift07.Models.Services
{
	public interface ICartManager
	{
		SavedCart SavedCart { get; }

		void AddToCart(int id);
		void RemoveFromCart(int id);
		void ClearCart();

		void SetBestallning(Bestallning bestallning);
		Task<Bestallning> GetBestallningAsync(bool kundPremium, int kundPoints);
	}

	public class CartManager : ICartManager
	{
		protected const string SESSION_KEY = "_cart";

		public SavedCart SavedCart => cart;

		protected SavedCart cart;
		protected readonly HttpContext httpContext;
		protected readonly TomasosContext dbContext;

		public CartManager(IHttpContextAccessor contextAccessor,
			TomasosContext dbContext)
		{
			httpContext = contextAccessor.HttpContext;
			this.dbContext = dbContext;

			cart = httpContext.Session.GetObject<SavedCart>(SESSION_KEY);
		}

		public void SetBestallning(Bestallning bestallning)
		{
			cart.orders = (from b in bestallning.BestallningMatratt
					select (foodId: b.Matratt.MatrattId, count: b.Antal))
				.ToArray();
		}

		public async Task<Bestallning> GetBestallningAsync(bool kundPremium, int kundPoints)
		{
			if (cart.orders == null)
				return new Bestallning();

			var bestallning = new Bestallning
			{
				BestallningMatratt = new List<BestallningMatratt>(),
				Levererad = false,
				BestallningDatum = DateTime.Now,
			};

			foreach (var order in cart.orders)
			{
				var matratt = await dbContext.Matratt
					.Include(m => m.MatrattTypNavigation)
					.Include(m => m.MatrattProdukt)
					.ThenInclude(p => p.Produkt)
					.FirstOrDefaultAsync(m => m.MatrattId == order.foodId);

				if (matratt != null)
				{
					bestallning.BestallningMatratt.Add(new BestallningMatratt
					{
						Matratt = matratt,
						MatrattId = matratt.MatrattId,
						Antal = order.count
					});
				}
			}
			
			bestallning.CalculateTotalPrice(
				kundPremium: kundPremium,
				kundPoints: kundPoints);

			return bestallning;
		}

		public void AddToCart(int id)
		{
			if (cart.TotalCount == 0)
			{
				cart.orders = new[] {(foodId: id, count: 1)};
			}
			else
			{
				for (int i = cart.orders.Length - 1; i >= 0; i--)
				{
					// Increment existing
					if (cart.orders[i].foodId == id)
					{
						cart.orders[i].count++;
						break;
					}

					// Add new item
					if (i == 0)
					{
						cart.orders = cart.orders.Append((foodId: id, count: 1)).ToArray();
						break;
					}
				}
			}
			SaveCartToSession();
		}

		public void RemoveFromCart(int id)
		{
			if (cart.orders != null)
			{
				for (var i = 0; i < cart.orders.Length; i++)
				{
					if (cart.orders[i].foodId == id && cart.orders[i].count > 0)
						cart.orders[i].count--;
				}
			}

			SaveCartToSession();
		}

		public void ClearCart()
		{
			cart = new SavedCart();

			SaveCartToSession();
		}

		private void SaveCartToSession()
		{
			// Remove empty entries
			cart.orders = cart.orders?.Where(o => o.count >= 0).ToArray();
			// Save to session
			httpContext.Session.SetObject(SESSION_KEY, cart);
		}
	}
}