using Admin.EndPoint.ViewModels.Catalogs;
using Application.Interfaces.Catalogs;
using Application.Interfaces.GetMenuItem;
using AutoMapper;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.EndPoint.AutoMapperConfigs
{
   public class CatalogVMAutoMapperConfigs : Profile
    {
       public CatalogVMAutoMapperConfigs()
        {
            CreateMap<CatalogType, CatalogTypeViewModel>().ReverseMap();

            CreateMap<CatalogType, CatalogTypeListDto>()
            .ForMember(dest => dest.SubTypeCount, option =>
             option.MapFrom(src => src.ChaildcatalogTypes.Count));
        }
    }
}
