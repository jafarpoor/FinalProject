using Application.Interfaces.Catalogs;
using Application.Interfaces.GetMenuItem;
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

            CreateMap<CatalogType, MenuItemDto>()
                .ForMember(dest => dest.Name, opt =>
                 opt.MapFrom(src => src.TypeName))
                .ForMember(dest => dest.ParentId, opt =>
                 opt.MapFrom(src => src.ParentCatalogTypeId))
                .ForMember(dest => dest.SubMenu, opt =>
                opt.MapFrom(src => src.ChaildcatalogTypes));
        }
    }
}
