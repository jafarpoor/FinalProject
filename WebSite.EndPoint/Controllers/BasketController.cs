using Application.Dtos;
using Application.Interfaces.Baskets;
using Application.Interfaces.Orders;
using Application.Interfaces.Payments;
using Application.Interfaces.Users;
using Domain.Order;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Models.ViewModels.Baskets;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private readonly IUserAddressService userAddressService;
        private readonly IOrderService orderService;
        private string UserId = null;
        private readonly IPaymentService paymentService;
        public BasketController(IBasketService basketService , SignInManager<User> signInManager,
                                IUserAddressService userAddressService ,
                                IOrderService orderService,
                                IPaymentService paymentService)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
            this.userAddressService = userAddressService;
            this.orderService = orderService;
            this.paymentService = paymentService;
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


        [Authorize]
        public IActionResult ShippingPayment()
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            var userId = ClaimUtility.GetUserId(User);
            model.Basket = basketService.GetBasketForUser(userId);
            model.UserAddresses = userAddressService.GetAddress(userId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod)
        {
            var userId = ClaimUtility.GetUserId(User);
            var basket = basketService.GetBasketForUser(userId);
            var Order = orderService.CreateOrder(basket.Id, Address, PaymentMethod);
            if (PaymentMethod == PaymentMethod.OnlinePaymnt)
            {
                //ثبت پرداخت
                var payment = paymentService.PayForOrder(Order);
                //ارسال به درگاه پرداخت
                return RedirectToAction("Index", "Pay", new { PaymentId = payment.PaymentId });
            }
            else
            {
                //برو به صفحه سفارشات من
                return RedirectToAction("Index", "Orders", new { area = "customers" });
            }
        }

    }
}
