using Admin.EndPoint.ViewModels.Catalogs;
using Application.Interfaces.Catalogs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.AutoMapperConfigs
{
    public class CatalogAutoMapperConfigs :Profile
    {
        public CatalogAutoMapperConfigs()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
        }
    }
}
