using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Discounts
{
   public interface IDiscountService
    {
        List<CatlogItemDto> GetCatalogItems(string searchKey);
    }
}
