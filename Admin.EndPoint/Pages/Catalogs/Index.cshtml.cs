using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces.Catalogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Catalogs
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeServiec _catalogTypeServiec;

        public IndexModel(ICatalogTypeServiec catalogTypeServiec)
        {
            _catalogTypeServiec = catalogTypeServiec;
        }
        public PaginatedItemsDto<CatalogTypeListDto> PaginatedItemsDto { get; set; }
        public void OnGet(int? ParentId , int Page =1 , int PageSize = 100)
        {
            PaginatedItemsDto = _catalogTypeServiec.GetList(ParentId , Page, PageSize);
        }
    }
}
