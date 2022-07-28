using Application.Dtos;
using Application.Interfaces.Catalogs;
using Application.Interfaces.Contexts;
using AutoMapper;
using Common;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Catalogs
{
    public class CatalogTypeService : ICatalogTypeServiec
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public CatalogTypeService(IDataBaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;  
        }
        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var result =_mapper.Map<CatalogType>(catalogType);
            //if (catalogType.ParentCatalogTypeId == null)
            //    result.ParentCatalogType = null;
            _context.catalogTypes.Add(result);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(catalogType,
                                                new List<string> { " با موفقیت ثبت شد" }, true);
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var result = _context.catalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);
            var model = _mapper.Map(catalogType, result);
            _context.catalogTypes.Update(model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(catalogType,
                                                new List<string> { "باموفقیت ویرایش شد" }
                                                , true);
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var catalogtype = _context.catalogTypes.Find(Id);
            var result = _mapper.Map<CatalogTypeDto>(catalogtype);
            return new BaseDto<CatalogTypeDto>(result, null, true);
            
        }

        public PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
           var model = _context.catalogTypes.AsQueryable()
                                             .Where(p => p.ParentCatalogTypeId == parentId)
                                             .PagedResult(page, pageSize, out totalCount);

            var result = _mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemsDto<CatalogTypeListDto>(page, pageSize, totalCount, result);

        }

        public BaseDto Remove(int catalogTypeId)
        {
            var Result = _context.catalogTypes.Find(catalogTypeId);
            _context.catalogTypes.Remove(Result);
            _context.SaveChanges();
            return new BaseDto(new List<string> { "باموفقیت حذف شد" }, true);
        }
    }
}
