using Application.Dtos;
using Application.Interfaces.Contexts;
using Application.Interfaces.Discounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Discounts
{
    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext context;

        public DiscountService(IDataBaseContext context)
        {
            this.context = context;
        }

        public bool ApplyDiscountInBasket(string CoponCode, int BasketId)
        {
            var basket = context.baskets
                          .Include(p => p.Items)
                          .Include(p => p.AppliedDiscount)
                          .SingleOrDefault(p => p.Id == BasketId);
            var discount = context.discounts.Where(p => p.CouponCode.Contains(CoponCode)).FirstOrDefault();
            basket.ApplyDiscountCode(discount);
            context.SaveChanges();
            return true;

        }

        public List<CatlogItemDto> GetCatalogItems(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var result = context.catalogItems
                             .Where(p => p.Name.Contains(searchKey))
                             .Select(p => new CatlogItemDto
                             {
                                 Id = p.Id ,
                                 Name = p.Name
                             }).ToList();

                return result;
            }
            else
            {
                var result = context.catalogItems
                         .Select(p => new CatlogItemDto
                         {
                             Id = p.Id,
                             Name = p.Name
                         }).Take(10).ToList();
                return result;
            }

        }

        public bool RemoveDiscountFromBasket(int BasketId)
        {
            var basket = context.baskets
                .SingleOrDefault(p => p.Id == BasketId);
            basket.RemoveDescount();
            context.SaveChanges();
            return true;
        }
    }
}
