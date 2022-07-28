using Domain.Catalogs;
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
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
