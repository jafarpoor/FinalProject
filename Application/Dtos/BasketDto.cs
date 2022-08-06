using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
   public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public int Total()
        {
            if(Items.Count>0)
            {
                return Items.Sum(p => p.Quantity * p.UnitPrice);
            }
            return 0;
        }
    }
}
