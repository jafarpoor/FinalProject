using Application.Interfaces.Contexts;
using Domain.Attributes;
using Domain.Baskets;
using Domain.Catalogs;
using Domain.Order;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DataBaseContext:DbContext,IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {

        }
        
        public DbSet<CatalogItem> catalogItems { get; set; }
        public DbSet<CatalogType> catalogTypes { get; set; }
        public DbSet<CatalogBrand> catalogBrands { get; set; }
        public DbSet<CatalogItemImage> catalogItemImages { get; set; }
        public DbSet<CatalogItemFeature> catalogItemFeatures { get; set; }

        public DbSet<Basket> baskets { get; set; }
        public DbSet<BasketItem> basketItems { get; set; }

        public DbSet<UserAddress>  userAddresses { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        protected   override void OnModelCreating(ModelBuilder builder)
        {
           

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if(entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute),true).Length>0)
                {
                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            builder.Entity<CatalogType>()
               .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Basket>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<BasketItem>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.ApplyConfiguration(new CatalogTypeEntityConfigurations());
            builder.ApplyConfiguration(new CatalogBrandEntityConfigurations());

            DataBaseContextSeed.CatalogSeed(builder);

            builder.Entity<Order>().OwnsOne(p => p.Address);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntries)
            {
                var entityType= item.Context.Model.FindEntityType(item.Entity.GetType());

                var inserted = entityType.FindProperty("InsertTime");
                var updated= entityType.FindProperty("UpdateTime");
                var RemoveTime= entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                if(item.State == EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }   
                if(item.State == EntityState.Modified && updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }   
                
                if(item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;


                    //چونکه نمیخواهیم از دیتابیس حذف کنیم و فقط میخواهیم تغییر وضعیت بدهیم
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();  
        }
    }
}
