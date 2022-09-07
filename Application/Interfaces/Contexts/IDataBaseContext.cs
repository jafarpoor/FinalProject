using Domain.Baskets;
using Domain.Catalogs;
using Domain.Order;
using Domain.Payments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
         DbSet<CatalogItem> catalogItems { get; set; }
         DbSet<CatalogType> catalogTypes { get; set; }
         DbSet<CatalogBrand> catalogBrands { get; set; }
        public DbSet<CatalogItemImage> catalogItemImages { get; set; }
        public DbSet<CatalogItemFeature> catalogItemFeatures { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<BasketItem> basketItems { get; set; }
        public DbSet<UserAddress> userAddresses { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Payment> payments { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
