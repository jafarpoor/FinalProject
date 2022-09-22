using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.Contexts;
using Infrastructure.UriComposer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs.GetCatalogItemsPDP
{
    public class GetCatalogItemPDPService : IGetCatalogItemPDPService
    {
        private readonly IDataBaseContext dataBaseContext;
        private readonly IUriComposerService uriComposerService;
        public GetCatalogItemPDPService(IDataBaseContext dataBaseContext ,
                                       IUriComposerService uriComposerService)
        {
            this.dataBaseContext = dataBaseContext;
            this.uriComposerService = uriComposerService;
        }
        public GetCatalogItemPDPDto Execute(int Id)
        {
            var catalogitem = dataBaseContext.catalogItems
               .Include(p => p.CatalogItemFeatures)
               .Include(p => p.CatalogItemImages)
               .Include(p => p.CatalogType)
               .Include(p => p.CatalogBrand)
               .SingleOrDefault(p => p.Id == Id);

                catalogitem.VisitCount += 1;
                dataBaseContext.SaveChanges();

            var feature = catalogitem.CatalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value
                }).ToList()
                .GroupBy(p => p.Group);

            var similarCatalogItems = dataBaseContext
               .catalogItems
               .Include(p => p.CatalogItemImages)
               .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId)
               .Take(10)
               .Select(p => new SimilarCatalogItemDto
               {
                   Id = p.Id,
                   Images = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                   Price = p.Price,
                   Name = p.Name
               }).ToList();

            return new GetCatalogItemPDPDto
            {
                Features = feature,
                SimilarCatalogs = similarCatalogItems,
                Id = catalogitem.Id,
                Name = catalogitem.Name,
                Brand = catalogitem.CatalogBrand.BrandName,
                Type = catalogitem.CatalogType.TypeName,
                Price = catalogitem.Price,
                Description = catalogitem.Description,
                Images = catalogitem.CatalogItemImages.Select(p => uriComposerService.ComposeImageUri(p.Src)).ToList(),

            };

        }
    }
}
