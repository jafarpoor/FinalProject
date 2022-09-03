using Application.Dtos;
using Application.Interfaces.Baskets;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Models.ViewComponents
{
    public class BasketComponent : ViewComponent
    {
        private readonly IBasketService basketService;
        private ClaimsPrincipal userClaimsPrincipal => ViewContext?.HttpContext.User;

      public  BasketComponent(IBasketService basketService )
        {
            this.basketService = basketService;
        }

        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket= basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimsPrincipal));
            }
            else
            {
                if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
                {
                    var buyerId = Request.Cookies[ClaimUtility.basketCookieName];
                    basket = basketService.GetBasketForUser(buyerId);
                }
            }
            return View(viewName: "BasketComponent", model: basket);
        }
    }
}
