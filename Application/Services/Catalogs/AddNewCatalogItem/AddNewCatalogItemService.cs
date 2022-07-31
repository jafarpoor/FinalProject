using Application.Dtos;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Catalogs.Dto;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs
{
   public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext dataBaseContxt;
        private readonly IMapper mapper;

        public AddNewCatalogItemService(IDataBaseContext dataBase , IMapper map)
        {
            dataBaseContxt = dataBase;
            mapper = map;
        }

        public BaseDto<int> Excute(AddNewCatalogItemDto itemDto)
        {
            var Result = mapper.Map<CatalogItem>(itemDto);
            dataBaseContxt.catalogItems.Add(Result);
            dataBaseContxt.SaveChanges();
            return new BaseDto<int>(Result.Id, new List<string> { "با موفقیت ثبت شد" }, true);
        }
    }
}
