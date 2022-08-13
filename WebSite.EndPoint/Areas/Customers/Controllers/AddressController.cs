using Application.Dtos;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Areas.Customers.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUserAddressService userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            this.userAddressService = userAddressService;
        }

        [Authorize]
        [Area("Customers")]
        public IActionResult Index()
        {
            var result = userAddressService.GetAddress(ClaimUtility.GetUserId(User));
            return View(result);
        }

        public IActionResult AddNewAdress()
        {
            return View(new AddUserAddressDto());
        }

        [HttpPost]
        public IActionResult AddNewAdress(AddUserAddressDto userAddressDto)
        {
            var userId = ClaimUtility.GetUserId(User);
            userAddressDto.UserId = userId;
            userAddressService.AddnewAddress(userAddressDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
