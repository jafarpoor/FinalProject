using Application.Dtos;
using Application.Interfaces.Contexts;
using Application.Interfaces.Discounts;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Discounts.AddNewDiscountServices
{
    public class AddNewDiscountService : IAddNewDiscountService
    {
        private readonly IDataBaseContext context;

        public AddNewDiscountService(IDataBaseContext context)
        {
            this.context = context;
        }


        public void Execute(AddNewDiscountDto addNewDiscountDto)
        {
            Discount result = new Discount
            {
                Name = addNewDiscountDto.Name,
                CouponCode = addNewDiscountDto.CouponCode,
                DiscountAmount = addNewDiscountDto.DiscountAmount,
                DiscountLimitationId = addNewDiscountDto.DiscountLimitationId,
                DiscountPercentage = addNewDiscountDto.DiscountPercentage,
                DiscountTypeId = addNewDiscountDto.DiscountTypeId,
                EndDate = addNewDiscountDto.EndDate,
                RequiresCouponCode = addNewDiscountDto.RequiresCouponCode,
                StartDate = addNewDiscountDto.StartDate,
                UsePercentage = addNewDiscountDto.UsePercentage,
            };

            if(addNewDiscountDto.appliedToCatalogItem != null)
            {
                var catalogItems = context.catalogItems.Where(p => addNewDiscountDto.appliedToCatalogItem.Contains(p.Id)).ToList();
                result.CatalogItems = catalogItems;
            }
            context.discounts.Add(result);
            context.SaveChanges();
        }
    }
}
