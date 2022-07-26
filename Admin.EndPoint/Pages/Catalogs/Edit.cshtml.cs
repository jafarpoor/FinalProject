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
    public class EditModel : PageModel
    {
        private readonly ICatalogTypeServiec catalogTypeService;
        private readonly IMapper mapper;

        public EditModel(ICatalogTypeServiec catalogTypeService, IMapper mapper)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
        }


        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel();
        public List<String> Message { get; set; } = new List<string>();
        public void OnGet(int Id)
        {
            var model = catalogTypeService.FindById(Id);
            if (model.IsSuccess)
                CatalogType = mapper.Map<CatalogTypeViewModel>(model.Data);
            Message = model.Message;
        }

        public IActionResult OnPost()
        {
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Edit(model);
            Message = result.Message;
            CatalogType = mapper.Map<CatalogTypeViewModel>(result.Data);
            return Page();
        }
    }
}
