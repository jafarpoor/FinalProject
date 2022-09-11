using Application.Interfaces.Discounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscountService discountService;
        public DiscountApiController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        [HttpGet]
        [Route("SearchCatalogItem")]
        public async Task<IActionResult> SearchCatalogItem(string term)
        {
            return Ok(discountService.GetCatalogItems(term));
        }
    }
}
