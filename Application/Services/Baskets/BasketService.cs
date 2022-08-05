using Application.Dtos;
using Application.Interfaces.Baskets;
using Application.Interfaces.Contexts;
using Domain.Baskets;
using Infrastructure.UriComposer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Baskets
{
   public class BasketService : IBasketService
    {
        private readonly IDataBaseContext dataBaseContxt;
        private readonly IUriComposerService uriComposerService;

        public BasketService(IDataBaseContext dataBaseContxt , IUriComposerService uriComposerService)
        {
            this.dataBaseContxt = dataBaseContxt;
            this.uriComposerService = uriComposerService;
        }

        public void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1)
        {
            var basket = dataBaseContxt.baskets.Find(basketId);
            if (basket == null)
                throw new Exception(" ");
            var price = dataBaseContxt.catalogItems.SingleOrDefault(p => p.Id == catalogItemId).Price;
            basket.AddItem(catalogItemId, quantity, price);
            dataBaseContxt.SaveChanges();
        }
        
        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = dataBaseContxt.baskets
                         .Include(p => p.Items)
                         .ThenInclude(p => p.CatalogItem)
                         .ThenInclude(p => p.CatalogItemImages)
                         .SingleOrDefault(p=>p.BuyerId == BuyerId);

            if(basket == null)
            {
                return CreateBasketForUser(BuyerId);
            }
            return new BasketDto
            {
                BuyerId = BuyerId,
                Id = basket.Id,
                Items = basket.Items.Select(p => new BasketItemDto
                {
                    CatalogItemid = p.CatalogItemId,
                    CatalogName = p.CatalogItem.Name,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                    Id = p.Id,
                    ImageUrl = uriComposerService.ComposeImageUri(p?.CatalogItem?.CatalogItemImages?.FirstOrDefault().Src ?? "")

                }).ToList()
            };
        }

        private BasketDto CreateBasketForUser(string buyerId)
        {
            Basket basket = new Basket(buyerId);
            dataBaseContxt.baskets.Add(basket);
            dataBaseContxt.SaveChanges();
            return new BasketDto
            {
                BuyerId = buyerId,
                Id = basket.Id
            };

        }

        public bool RemoveBasketItem(int ItemId)
        {
            var result = dataBaseContxt.basketItems.SingleOrDefault(p => p.Id == ItemId);
            dataBaseContxt.basketItems.Remove(result);
            dataBaseContxt.SaveChanges();
            return true;
        }

        public bool SetQuantities(int itemId, int quantity)
        {
            var Result = dataBaseContxt.basketItems.SingleOrDefault(p => p.Id == itemId);
            Result.SetQuantity(quantity);
            dataBaseContxt.SaveChanges();
            return true;

;        }
    }
}
