using Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
   public class DataBaseContextSeed
    {
        public static void CatalogSeed(ModelBuilder modelBuilder)
        {
            foreach (var catalog in GetCatalogTypes())
            {
                modelBuilder.Entity<CatalogType>().HasData(catalog);
            }
            foreach (var brand in GetCatalogBrands())
            {
                modelBuilder.Entity<CatalogBrand>().HasData(brand);
            }
        }


        private static IEnumerable<CatalogType> GetCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() {  Id=1,  TypeName="کالای دیجیتال"},

                new CatalogType() {  Id= 2,  TypeName="لوازم جانبی گوشی" , ParentCatalogTypeId = 1},
                new CatalogType() {  Id= 3,  TypeName="پایه نگهدارنده گوشی" , ParentCatalogTypeId=2},
                new CatalogType() {  Id= 4,  TypeName="پاور بانک (شارژر همراه)", ParentCatalogTypeId=2},
                new CatalogType() {  Id= 5,  TypeName="کیف و کاور گوشی", ParentCatalogTypeId=2},



            };
        }

        private static IEnumerable<CatalogBrand> GetCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Id=1, BrandName = "سامسونگ" },
                new CatalogBrand() { Id=2, BrandName = "شیائومی " },
                new CatalogBrand() { Id=3, BrandName = "اپل" },
                new CatalogBrand() { Id=4, BrandName = "هوآوی" },
                new CatalogBrand() { Id=5, BrandName = "نوکیا " },
                new CatalogBrand() { Id=6, BrandName = "ال جی" }
            };
        }
    }
}
