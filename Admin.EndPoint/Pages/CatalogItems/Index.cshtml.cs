using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Services.Catalogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemServiec catalogItemService;

        public IndexModel(ICatalogItemServiec catalogItemService)
        {
            this.catalogItemService = catalogItemService;
        }
        public PaginatedItemsDto<CatalogItemListItemDto> CatalogItems { get; set; }

        public void OnGet(int Page = 1 , int PageSize=100 )
        {
            CatalogItems = catalogItemService.GetCatalogItemList(Page , PageSize);
        }
    }
}
