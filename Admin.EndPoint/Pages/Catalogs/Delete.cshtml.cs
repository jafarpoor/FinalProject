using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.ViewModels.Catalogs;
using Application.Interfaces.Catalogs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Catalogs
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogTypeServiec catalogTypeService;
        private readonly IMapper mapper;

        public DeleteModel(ICatalogTypeServiec catalogTypeService, IMapper mapper)
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

            var result = catalogTypeService.Remove(CatalogType.Id);
            Message = result.Message;
            if (result.IsSuccess)
            {
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
