using Application.Dtos;
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
        public IActionResult Index(CatlogPLPRequestDto dto)
        {
            return View(getCatalogItemPLPServie.Execute(dto));
        }

        public IActionResult Details(int id)
        {
            var data = getCatalogItemPDPService.Execute(id);
            return View(data);
        }
    }
}
