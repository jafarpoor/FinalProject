using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.ViewModels.Catalogs;
using Application.Interfaces.Catalogs;
using Application.Services.Catalogs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Catalogs
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogTypeServiec catalogTypeService;
        private readonly IMapper mapper;

        public CreateModel(ICatalogTypeServiec catalogTypeService, IMapper mapper)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
        }

        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public List<String> Message { get; set; } = new List<string>();

        public void OnGet(int? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Add(model);
            if (result.IsSuccess)
            {
                return RedirectToPage("index", new { parentId = CatalogType.ParentCatalogTypeId });
            }
            Message = result.Message;
            return Page();
        }
    }
}
