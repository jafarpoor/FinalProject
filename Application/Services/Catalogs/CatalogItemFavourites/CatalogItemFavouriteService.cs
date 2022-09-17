using Application.Dtos;
using Application.Interfaces.Catalogs.CatalogItemFavourites;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.Contexts;
using Common;
using Domain.Catalogs;
using Infrastructure.UriComposer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs.CatalogItemFavourites
{
    public class CatalogItemFavouriteService : ICatalogItemFavouriteService
    {
        private readonly IDataBaseContext _context;
        private readonly IUriComposerService _uriComposerService;

        public CatalogItemFavouriteService(IDataBaseContext context , IUriComposerService uriComposerService)
        {
            _context = context;
            _uriComposerService = uriComposerService;
        }
        public void AddToMyFavourite(string UserId, int CatalogItemId)
        {
            var catalogItem = _context.catalogItems.SingleOrDefault(p => p.Id == CatalogItemId);
            CatalogItemFavourite catalogItemFavourite = new CatalogItemFavourite()
            {
                CatalogItem = catalogItem ,
                UserId = UserId
            };

            _context.catalogItemFavourites.Add(catalogItemFavourite);
            _context.SaveChanges();
        }

        public PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20)
        {
            var result = _context.catalogItems
                          .Include(p => p.CatalogItemImages)
                          .Include(p => p.Discounts)
                          .Include(p => p.CatalogItemFavourites)
                          .Where(p => p.CatalogItemFavourites.Any(f => f.UserId == UserId))
                          .OrderByDescending(p=>p.Id)
                          .AsQueryable();

            int rowCount = 0;
            var modelList = result.PagedResult(page , pageSize ,out rowCount).ToList()
                .Select(p=> new FavouriteCatalogItemDto { 
                    Image = _uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src) ,
                    Name = p.Name ,
                    Price = p.Price ,
                    Id = p.Id ,
                    AvailableStock = p.AvailableStock ,
                }).ToList();

          return new PaginatedItemsDto<FavouriteCatalogItemDto>(page, pageSize, rowCount, modelList);
        }
    }
}
