using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.ViewModels.Catalogs;
using Application.Interfaces.Catalogs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Admin.EndPoint.Pages.Catalogs
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogTypeServiec catalogTypeService;
        private readonly IMapper mapper;
        private readonly ILogger<DeleteModel> logger;
        public DeleteModel(ICatalogTypeServiec catalogTypeService, IMapper mapper , ILogger<DeleteModel> logger)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
            this.logger = logger;
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
                logger.LogInformation("New Prsern {Person}", result);
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
