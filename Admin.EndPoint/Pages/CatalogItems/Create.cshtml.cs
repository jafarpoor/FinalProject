using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Services.Catalogs;
using Infrastructure.Api.ImageServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class CreateModel : PageModel
    {
        private readonly IAddNewCatalogItemService addNewCatalogItemService;
        private readonly ICatalogItemServiec catalogItemService;
        private readonly IImageUploadService imageUploadService;

        public CreateModel(IAddNewCatalogItemService addNewCatalogItemService
                         , ICatalogItemServiec catalogItemService
                         , IImageUploadService imageUploadService)
        {
            this.addNewCatalogItemService = addNewCatalogItemService;
            this.catalogItemService = catalogItemService;
            this.imageUploadService = imageUploadService;
        }

        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }
        [BindProperty]
        public AddNewCatalogItemDto Data { get; set; }

        [BindProperty]
        public List<IFormFile> Files { get; set; }
        public void OnGet()
        {
            Categories = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
            Brands = new SelectList(catalogItemService.GetBrand(), "Id", "Brand");
        }

        public JsonResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var allError = ModelState.Values.SelectMany(p => p.Errors);
                return new JsonResult(new BaseDto<int>(0, allError.Select(p => p.ErrorMessage).ToList(), false));
            }

                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    Files.Add(file);
                }

            List<AddNewCatalogItemImage_Dto> images = new List<AddNewCatalogItemImage_Dto>();
            if (Files.Count > 0)
            {
                //Upload 
                var result = imageUploadService.Upload(Files);
                foreach (var item in result)
                {
                    images.Add(new AddNewCatalogItemImage_Dto { Src = item });
                }
            }
            Data.Images = images;
            var resultService = addNewCatalogItemService.Excute(Data);
            return new JsonResult(resultService);
        }


    }
}
