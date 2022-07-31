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

        public ProductController(IGetCatalogItemPLPServiec getCatalogItemPLPServie)
        {
            this.getCatalogItemPLPServie = getCatalogItemPLPServie;
        }
        public IActionResult Index(int Page =1 , int PageSize=100)
        {
            return View(getCatalogItemPLPServie.Execute(Page, PageSize));
        }
    }
}
