using Application.Dtos;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.Contexts;
using Common;
using Infrastructure.UriComposer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetMenuItem.GetCatalogItemPLP
{
    public class GetCatalogItemPLPServie : IGetCatalogItemPLPServiec
    {

        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public GetCatalogItemPLPServie(IDataBaseContext context , IUriComposerService uri)
        {
            this.context = context;
            uriComposerService = uri;
        }
        public PaginatedItemsDto<GetCatalogItemPLPDto> Execute(CatlogPLPRequestDto catlogPLPRequestDto)
        {
            int RowCount = 0;
            var Result = context.catalogItems
                        .Include(prop => prop.CatalogItemImages)
                        .OrderByDescending(p => p.Id)
                        .AsQueryable();

            if (catlogPLPRequestDto.brandId != null)
            {
                Result = Result.Where(p=>catlogPLPRequestDto.brandId.Any(b=> b == p.CatalogBrandId));
                                
            }
            if(catlogPLPRequestDto.CatalogTypeId != null)
            {
                Result = Result.Where(p => catlogPLPRequestDto.CatalogTypeId == p.CatalogTypeId);
            }

            if (!string.IsNullOrEmpty(catlogPLPRequestDto.SearchKey))
            {
                Result = Result.Where(P => P.Name.Contains(catlogPLPRequestDto.SearchKey)
                                   || (P.Description.Contains(catlogPLPRequestDto.SearchKey)));
            }

            if (catlogPLPRequestDto.AvailableStock)
            {
                Result = Result.Where(p => p.AvailableStock > 0);
            }

            if (catlogPLPRequestDto.SortType == SortType.Bestselling)
            {
                Result = Result.Include(p => p.OrderItems)
                                .OrderByDescending(p => p.OrderItems.Count());
            }

            if (catlogPLPRequestDto.SortType == SortType.cheapest)
            {
                Result = Result.Include(p=>p.Discounts)
                               .OrderBy(p=>p.Price);
            }
            if(catlogPLPRequestDto.SortType == SortType.mostExpensive)
            {
                Result = Result.Include(p => p.Discounts)
                              .OrderByDescending(p => p.Price);
            }
            if (catlogPLPRequestDto.SortType == SortType.MostVisited)
            {
                Result = Result.OrderByDescending(p => p.VisitCount);
            }

            if (catlogPLPRequestDto.SortType == SortType.MostPopular)
            {
                Result = Result.Include(p => p.CatalogItemFavourites)
                               .OrderByDescending(p => p.CatalogItemFavourites.Count);
            }

            if (catlogPLPRequestDto.SortType == SortType.newest)
            {
                Result = Result.OrderByDescending(p => p.Id);
            }

         var data =   Result.PagedResult(catlogPLPRequestDto.page, catlogPLPRequestDto.pageSize, out RowCount)
                        .Select(p => new GetCatalogItemPLPDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            Rate = 4,
                            Image = uriComposerService
                           .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                        }).ToList();

            return new PaginatedItemsDto<GetCatalogItemPLPDto>(catlogPLPRequestDto.page, catlogPLPRequestDto.pageSize, RowCount, data);
        }
    }
}
