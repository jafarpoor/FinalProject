using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Baskets
{
   public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);

        bool RemoveBasketItem(int ItemId);
        bool SetQuantities(int itemId, int quantity);
        BasketDto GetBasketForUser(string UserId);
    }
}
