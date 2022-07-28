using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs
{
  public class CatalogItemServiec : ICatalogItemServiec
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public CatalogItemServiec(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<CatalogBrandDto> GetBrand()
        {
            var Result = context.catalogBrands.OrderBy(p => p.BrandName).Take(500).ToList();
            var catalogBrand = mapper.Map<List<CatalogBrandDto>>(Result);
            return catalogBrand;
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var Result = context.catalogTypes
                            .Include(p => p.ParentCatalogType)
                            .Include(p => p.ParentCatalogType)
                            .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                            .Include(p => p.ChaildcatalogTypes)
                            .Where(p => p.ParentCatalogType != null)
                            .Where(p => p.ChaildcatalogTypes.Count == 0)
                            .Select(p => new
                            {
                                p.Id,
                                p.TypeName,
                                p.ParentCatalogType,
                                p.ChaildcatalogTypes
                            }
                            ).ToList().Select(p => new ListCatalogTypeDto
                            {
                                Id = p.Id,
                                Type = $"{p?.TypeName ?? ""} - {p?.ParentCatalogType?.TypeName ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.TypeName ?? ""}
                            }).ToList();

            return Result;
        }
    }
}
