using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NackademinUppgift07.DataModels
{
    public static class DbInitializer
    {
        public static async Task Initialize(TomasosContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Add roles if they don't exist
            string[] roles = { "Admin", "Staff", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Add admin user if it doesn't exist
            if (!context.Users.Any(u => u.Email == "admin@tomasos.com"))
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@tomasos.com",
                    Email = "admin@tomasos.com",
                    DisplayName = "Admin User",
                    Address = "Restaurant Street 1",
                    PostalCode = "12345",
                    City = "Stockholm",
                    Points = 0,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Add staff members if they don't exist
            var staffMembers = new[]
            {
                new { Email = "chef@tomasos.com", Name = "Mario Chef", Role = "Staff" },
                new { Email = "waiter@tomasos.com", Name = "Luigi Server", Role = "Staff" }
            };

            foreach (var staff in staffMembers)
            {
                if (!context.Users.Any(u => u.Email == staff.Email))
                {
                    var staffUser = new ApplicationUser
                    {
                        UserName = staff.Email,
                        Email = staff.Email,
                        DisplayName = staff.Name,
                        Address = "Restaurant Street 1",
                        PostalCode = "12345",
                        City = "Stockholm",
                        Points = 0,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(staffUser, "Staff123!");
                    await userManager.AddToRoleAsync(staffUser, staff.Role);
                }
            }

            // Add regular customer if it doesn't exist
            if (!context.Users.Any(u => u.Email == "customer@tomasos.com"))
            {
                var customer = new ApplicationUser
                {
                    UserName = "customer@tomasos.com",
                    Email = "customer@tomasos.com",
                    DisplayName = "John Customer",
                    Address = "Customer Street 123",
                    PostalCode = "12345",
                    City = "Stockholm",
                    Points = 0,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(customer, "Customer123!");
                await userManager.AddToRoleAsync(customer, "Customer");
            }

            // Add dish types if they don't exist
            if (!context.MatrattTyp.Any())
            {
                var dishTypes = new[]
                {
                    new MatrattTyp { Beskrivning = "Pizza" },
                    new MatrattTyp { Beskrivning = "Pasta" },
                    new MatrattTyp { Beskrivning = "Sallad" },
                    new MatrattTyp { Beskrivning = "Dryck" }
                };

                foreach (var type in dishTypes)
                {
                    context.MatrattTyp.Add(type);
                }
                await context.SaveChangesAsync();
            }

            // Add products if they don't exist
            if (!context.Produkt.Any())
            {
                var products = new[]
                {
                    // Pizza ingredients
                    new Produkt { ProduktNamn = "Tomatsås" },
                    new Produkt { ProduktNamn = "Mozzarella" },
                    new Produkt { ProduktNamn = "Skinka" },
                    new Produkt { ProduktNamn = "Champinjoner" },
                    new Produkt { ProduktNamn = "Pepperoni" },
                    new Produkt { ProduktNamn = "Lök" },
                    new Produkt { ProduktNamn = "Oliver" },
                    new Produkt { ProduktNamn = "Basilika" },
                    // Pasta ingredients
                    new Produkt { ProduktNamn = "Spaghetti" },
                    new Produkt { ProduktNamn = "Penne" },
                    new Produkt { ProduktNamn = "Köttfärssås" },
                    new Produkt { ProduktNamn = "Pesto" },
                    // Salad ingredients
                    new Produkt { ProduktNamn = "Salladsblad" },
                    new Produkt { ProduktNamn = "Tomater" },
                    new Produkt { ProduktNamn = "Gurka" },
                    new Produkt { ProduktNamn = "Fetaost" },
                    // Drinks
                    new Produkt { ProduktNamn = "Cola" },
                    new Produkt { ProduktNamn = "Sprite" },
                    new Produkt { ProduktNamn = "Fanta" },
                    new Produkt { ProduktNamn = "Mineralvatten" }
                };

                foreach (var product in products)
                {
                    context.Produkt.Add(product);
                }
                await context.SaveChangesAsync();
            }

            // Add dishes if they don't exist
            if (!context.Matratt.Any())
            {
                var pizzaType = await context.MatrattTyp.FirstAsync(t => t.Beskrivning == "Pizza");
                var pastaType = await context.MatrattTyp.FirstAsync(t => t.Beskrivning == "Pasta");
                var saladType = await context.MatrattTyp.FirstAsync(t => t.Beskrivning == "Sallad");
                var drinkType = await context.MatrattTyp.FirstAsync(t => t.Beskrivning == "Dryck");

                var dishes = new[]
                {
                    // Pizzas
                    new Matratt 
                    { 
                        MatrattNamn = "Margherita", 
                        Beskrivning = "Klassisk pizza med tomatsås, mozzarella och basilika",
                        Pris = 95,
                        MatrattTyp = pizzaType.MatrattTyp1
                    },
                    new Matratt 
                    { 
                        MatrattNamn = "Pepperoni", 
                        Beskrivning = "Pizza med tomatsås, mozzarella och pepperoni",
                        Pris = 105,
                        MatrattTyp = pizzaType.MatrattTyp1
                    },
                    // Pasta dishes
                    new Matratt 
                    { 
                        MatrattNamn = "Spaghetti Bolognese", 
                        Beskrivning = "Spaghetti med hemlagad köttfärssås",
                        Pris = 110,
                        MatrattTyp = pastaType.MatrattTyp1
                    },
                    new Matratt 
                    { 
                        MatrattNamn = "Penne Pesto", 
                        Beskrivning = "Penne pasta med basilika pesto",
                        Pris = 100,
                        MatrattTyp = pastaType.MatrattTyp1
                    },
                    // Salads
                    new Matratt 
                    { 
                        MatrattNamn = "Grekisk Sallad", 
                        Beskrivning = "Fräsch sallad med fetaost, oliver och grönsaker",
                        Pris = 85,
                        MatrattTyp = saladType.MatrattTyp1
                    },
                    // Drinks
                    new Matratt 
                    { 
                        MatrattNamn = "Läsk", 
                        Beskrivning = "Val av Cola, Sprite eller Fanta",
                        Pris = 25,
                        MatrattTyp = drinkType.MatrattTyp1
                    },
                    new Matratt 
                    { 
                        MatrattNamn = "Mineralvatten", 
                        Beskrivning = "Kolsyrat mineralvatten",
                        Pris = 20,
                        MatrattTyp = drinkType.MatrattTyp1
                    }
                };

                foreach (var dish in dishes)
                {
                    context.Matratt.Add(dish);
                }
                await context.SaveChangesAsync();

                // Add ingredients to dishes
                var tomatsas = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Tomatsås");
                var mozzarella = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Mozzarella");
                var basilika = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Basilika");
                var pepperoni = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Pepperoni");
                var spaghetti = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Spaghetti");
                var kottfarssas = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Köttfärssås");
                var penne = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Penne");
                var pesto = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Pesto");
                var sallad = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Salladsblad");
                var fetaost = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Fetaost");
                var oliver = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Oliver");
                var cola = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Cola");
                var mineralvatten = await context.Produkt.FirstAsync(p => p.ProduktNamn == "Mineralvatten");

                var margherita = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Margherita");
                var pepperoniPizza = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Pepperoni");
                var spaghettiB = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Spaghetti Bolognese");
                var pennePesto = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Penne Pesto");
                var grekiskSallad = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Grekisk Sallad");
                var lask = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Läsk");
                var mineralvattenDish = await context.Matratt.FirstAsync(m => m.MatrattNamn == "Mineralvatten");

                // Add ingredients to dishes
                var ingredients = new[]
                {
                    // Margherita ingredients
                    new MatrattProdukt { Matratt = margherita, Produkt = tomatsas },
                    new MatrattProdukt { Matratt = margherita, Produkt = mozzarella },
                    new MatrattProdukt { Matratt = margherita, Produkt = basilika },

                    // Pepperoni ingredients
                    new MatrattProdukt { Matratt = pepperoniPizza, Produkt = tomatsas },
                    new MatrattProdukt { Matratt = pepperoniPizza, Produkt = mozzarella },
                    new MatrattProdukt { Matratt = pepperoniPizza, Produkt = pepperoni },

                    // Spaghetti Bolognese ingredients
                    new MatrattProdukt { Matratt = spaghettiB, Produkt = spaghetti },
                    new MatrattProdukt { Matratt = spaghettiB, Produkt = kottfarssas },

                    // Penne Pesto ingredients
                    new MatrattProdukt { Matratt = pennePesto, Produkt = penne },
                    new MatrattProdukt { Matratt = pennePesto, Produkt = pesto },

                    // Greek Salad ingredients
                    new MatrattProdukt { Matratt = grekiskSallad, Produkt = sallad },
                    new MatrattProdukt { Matratt = grekiskSallad, Produkt = fetaost },
                    new MatrattProdukt { Matratt = grekiskSallad, Produkt = oliver },

                    // Drinks
                    new MatrattProdukt { Matratt = lask, Produkt = cola },
                    new MatrattProdukt { Matratt = mineralvattenDish, Produkt = mineralvatten }
                };

                foreach (var ingredient in ingredients)
                {
                    context.MatrattProdukt.Add(ingredient);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
