using Application.Interfaces.Contexts;
using Application.Interfaces.GetMenuItem;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetMenuItem
{
   public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public GetMenuItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<MenuItemDto> Execute()
        {
            var catalogType = context.catalogTypes.Include(p => p.ParentCatalogType).ToList();
            var model = mapper.Map<List<MenuItemDto>>(catalogType);
            return model;
        }
    }
}
