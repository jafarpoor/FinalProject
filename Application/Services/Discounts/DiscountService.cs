using Application.Dtos;
using Application.Interfaces.Contexts;
using Application.Interfaces.Discounts;
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
                         .Where(p => p.Name.Contains(searchKey))
                         .Select(p => new CatlogItemDto
                         {
                             Id = p.Id,
                             Name = p.Name
                         }).Take(10).ToList();
                return result;
            }

        }
    }
}
