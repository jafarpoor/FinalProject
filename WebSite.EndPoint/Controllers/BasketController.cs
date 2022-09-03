using Application.Dtos;
using Application.Interfaces.Baskets;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private string UserId = null;
        public BasketController(IBasketService basketService , SignInManager<User> signInManager )
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(int CatalogItemId , int quantity = 1)
        {
            var result = GetOrSetBasket();
            basketService.AddItemToBasket(result.Id, CatalogItemId);
            return RedirectToAction("Index");
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                UserId = ClaimUtility.GetUserId(User);
              return  basketService.GetOrCreateBasketForUser(UserId);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(UserId);
            }
        }

        private void SetCookiesForBasket()
        {
            if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
            {
                UserId = Request.Cookies[ClaimUtility.basketCookieName];
            }
            if (UserId != null)
                return;
            UserId = Guid.NewGuid().ToString();
            var cookeoptions = new CookieOptions { IsEssential = true };
            cookeoptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(ClaimUtility.basketCookieName, UserId, cookeoptions);
        }

        [HttpPost]
        public IActionResult RemoveItemFromBasket(int ItemId)
        {
            basketService.RemoveBasketItem(ItemId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult setQuantity(int basketItemId, int quantity)
        {
            return Json(basketService.SetQuantities(basketItemId, quantity));
        }


    }
}
