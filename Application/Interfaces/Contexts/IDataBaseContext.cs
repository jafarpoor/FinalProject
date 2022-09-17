using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
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
         DbSet<CatalogItemImage> catalogItemImages { get; set; }
         DbSet<CatalogItemFeature> catalogItemFeatures { get; set; }
         DbSet<Basket> baskets { get; set; }
         DbSet<BasketItem> basketItems { get; set; }
         DbSet<UserAddress> userAddresses { get; set; }
         DbSet<Order> orders { get; set; }
         DbSet<OrderItem> orderItems { get; set; }
         DbSet<Payment> payments { get; set; }
         DbSet<Discount> discounts { get; set; }
         DbSet<DiscountUsageHistory> discountUsageHistories { get; set; }
         DbSet<CatalogItemFavourite> catalogItemFavourites { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
