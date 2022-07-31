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
        public PaginatedItemsDto<GetCatalogItemPLPDto> Execute(int Page, int PageSize)
        {
            int RowCount = 0;
            var Result = context.catalogItems
                        .Include(prop => prop.CatalogItemImages)
                        .OrderByDescending(p=>p.Id)
                        .PagedResult(Page , PageSize ,out RowCount)
                        .Select(p => new GetCatalogItemPLPDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            Rate = 4,
                            Image = uriComposerService
                           .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                        }).ToList();

            return new PaginatedItemsDto<GetCatalogItemPLPDto>(Page, PageSize, RowCount, Result);
        }
    }
}
