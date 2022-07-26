using Application.Interfaces.Catalogs;
using AutoMapper;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.AutoMapperConfigs
{
   public class CatalogVMAutoMapperConfigs : Profile
    {
       public CatalogVMAutoMapperConfigs()
        {
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

            CreateMap<CatalogType, CatalogTypeListDto>()
            .ForMember(dest => dest.SubTypeCount, option =>
             option.MapFrom(src => src.ChaildcatalogTypes.Count));
        }
    }
}
