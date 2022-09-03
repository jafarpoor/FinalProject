using Application.Dtos;
using Application.Interfaces.Users;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Areas.Customers.Controllers
{
    //[Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserAddressService userAddressService;

        public AddressController(IUserAddressService userAddressService )
        {
            this.userAddressService = userAddressService;
        }

        public IActionResult Index()
        {
            var result = userAddressService.GetAddress(ClaimUtility.GetUserId(User));
            return View(result);
        }

        public IActionResult AddNewAddress()
        {
            return View(new AddUserAddressDto());
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDto userAddressDto)
        {
            var userId = ClaimUtility.GetUserId(User);
            userAddressDto.UserId = userId;
            userAddressService.AddnewAddress(userAddressDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
