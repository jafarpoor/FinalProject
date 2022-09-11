using Admin.EndPoint.AutoMapperConfigs;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.Contexts;
using Application.Interfaces.Discounts;
using Application.Services.Catalogs;
using Application.Services.Discounts;
using Application.Services.Discounts.AddNewDiscountServices;
using FluentValidation;
using Infrastructure.Api.ImageServer;
using Infrastructure.AutoMapperConfigs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddControllers();
            #region connection String SqlServer
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddTransient<ICatalogTypeServiec, CatalogTypeService>();
            services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
            services.AddTransient<ICatalogItemServiec, CatalogItemServiec>();
            services.AddTransient<IImageUploadService, ImageUploadService>();


            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
            #endregion

            //mapper
            services.AddAutoMapper(typeof(CatalogVMAutoMapperConfigs));
            services.AddAutoMapper(typeof(CatalogAutoMapperConfigs));


            //fluentValidation
            services.AddTransient<IValidator<AddNewCatalogItemDto>, AddNewCatalogItemDtoValidator>();

            services.AddTransient<IAddNewDiscountService, AddNewDiscountService>();
            services.AddTransient<IDiscountService, DiscountService>();
            
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
