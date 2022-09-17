using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.CatalogItemFavourites;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class MyFavouriteController : Controller
    {
        private readonly ICatalogItemFavouriteService _catalogItemService;
        private readonly UserManager<User> _userManager;

        public MyFavouriteController(ICatalogItemFavouriteService catalogItemService , UserManager<User> userManager)
        {
            _catalogItemService = catalogItemService;
            _userManager = userManager;
        }

        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            var user = _userManager.GetUserAsync(User).Result;
          var data =  _catalogItemService.GetMyFavourite(user.Id);
            return View(data);
        }

        public IActionResult AddToMyFavourite(int CatalogItemId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _catalogItemService.AddToMyFavourite(user.Id, CatalogItemId);
            return RedirectToAction(nameof(Index));
        }
    }
}
