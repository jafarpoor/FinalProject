using Application.Dtos;
using Application.Interfaces.Catalogs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Catalogs.CatalogItemFavourites
{
   public interface ICatalogItemFavouriteService
    {
        void AddToMyFavourite(string UserId, int CatalogItemId);
        PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20);
    }
}
