
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.GetMenuItem;
using AutoMapper;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapperConfigs
{
    public class CatalogAutoMapperConfigs :Profile
    {
        public CatalogAutoMapperConfigs()
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
                    opt.MapFrom(src => src.ChaildcatalogTypes)).ReverseMap();

            CreateMap<CatalogItemFeature, AddNewCatalogItemFeature_dto>().ReverseMap();
            CreateMap<CatalogItemImage, AddNewCatalogItemImage_Dto>().ReverseMap();
            CreateMap<CatalogItem, AddNewCatalogItemDto>()
                .ForMember(opt=>opt.Features , opt=>
                opt.MapFrom(src=>src.CatalogItemFeatures))
                .ForMember(opt=>opt.Images , opt=>
                opt.MapFrom(src=>src.CatalogItemImages)).ReverseMap();

            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(p=>p.Brand , opt=>opt.MapFrom(src=>src.BrandName))
                .ReverseMap();

            CreateMap<CatalogType, CatalogTypeDto>()
                .ForMember(p=>p.TypeName , opt=>opt.MapFrom(src=>src.TypeName))
                .ReverseMap();


        }
    }
}
