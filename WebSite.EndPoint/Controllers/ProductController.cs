using Application.Interfaces.Catalogs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPServiec getCatalogItemPLPServie;
        private readonly IGetCatalogItemPDPService getCatalogItemPDPService;

        public ProductController(IGetCatalogItemPLPServiec getCatalogItemPLPServie , IGetCatalogItemPDPService getCatalogItemPDPService)
        {
            this.getCatalogItemPLPServie = getCatalogItemPLPServie;
            this.getCatalogItemPDPService = getCatalogItemPDPService;
        }
        public IActionResult Index(int Page =1 , int PageSize=100)
        {
            return View(getCatalogItemPLPServie.Execute(Page, PageSize));
        }

        public IActionResult Details(int id)
        {
            var data = getCatalogItemPDPService.Execute(id);
            return View(data);
        }
    }
}
