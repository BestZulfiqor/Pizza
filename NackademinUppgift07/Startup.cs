using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NackademinUppgift07.DataModels;
using NackademinUppgift07.Utility;
using NackademinUppgift07.Models;
using NackademinUppgift07.Models.Services;

namespace NackademinUppgift07
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<TomasosContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Tomasos")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache();

            services.AddHttpContextAccessor();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    // Weaken the password validator
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength =
                        AttributesUtilities.Presets.GetMinLength<ViewLogin>(nameof(ViewLogin.Losenord)) ?? 6;
                })
                .AddEntityFrameworkStores<TomasosContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICartManager, CartManager>();
            services.AddTransient<MatrattRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TomasosContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Tomasos}/{action=Index}/{id?}");
            });

            // Initialize the database with sample data
            DbInitializer.Initialize(context, userManager, roleManager).Wait();
        }
    }
}
