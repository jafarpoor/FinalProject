using Admin.EndPoint.AutoMapperConfigs;
using Application.Interfaces.Baskets;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.CatalogItemFavourites;
using Application.Interfaces.Contexts;
using Application.Interfaces.Discounts;
using Application.Interfaces.Orders;
using Application.Interfaces.Payments;
using Application.Interfaces.Users;
using Application.Services.Baskets;
using Application.Services.Catalogs.CatalogItemFavourites;
using Application.Services.Catalogs.GetCatalogItemsPDP;
using Application.Services.Discounts;
using Application.Services.GetMenuItem;
using Application.Services.GetMenuItem.GetCatalogItemPLP;
using Application.Services.Orders;
using Application.Services.Payments;
using Application.Services.Users;
using Domain.Catalogs;
using Domain.Users;
using Infrastructure.Api.ImageServer;
using Infrastructure.AutoMapperConfigs;
using Infrastructure.IdentityConfigs;
using Infrastructure.UriComposer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Sub;
            });
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //});
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            #region  Connection String
            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddTransient<IDataBaseContext, DataBaseContext>();
            services.AddTransient<IIdentityDatabaseContext, IdentityDatabaseContext>();
            services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
            services.AddScoped<IUserClaimsPrincipalFactory<User>, AddMyClaims>();
            services.AddTransient<IGetMenuItemService, GetMenuItemService>();
            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddTransient<IUriComposerService, UriComposerService>();
            services.AddTransient<IGetCatalogItemPLPServiec, GetCatalogItemPLPServie>();
            services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
            services.AddTransient<ICatalogItemFavouriteService, CatalogItemFavouriteService>();
            services.AddIdentityService(Configuration);
            services.AddAuthorization();
            services.ConfigureApplicationCookie(option =>
            {
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                option.LoginPath = "/account/login";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.SlidingExpiration = true;
            });


            //mappper
            services.AddAutoMapper(typeof(CatalogAutoMapperConfigs));
            services.AddAutoMapper(typeof(UserMapperConfigs));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(
                      name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
