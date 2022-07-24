using Application.Interfaces.Contexts;
using Domain.Attributes;
using Domain.Catalogs;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
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

        protected   override void OnModelCreating(ModelBuilder builder)
        {
           

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if(entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute),true).Length>0)
                {
                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved");
                }
            }

            builder.ApplyConfiguration(new CatalogTypeEntityConfigurations());
            builder.ApplyConfiguration(new CatalogBrandEntityConfigurations());

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
                }
            }
            return base.SaveChanges();  
        }
    }
}
