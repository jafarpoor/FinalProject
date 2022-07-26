using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
   public class PaginatedItemsDto<TEntity> where TEntity : class
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }

        public IEnumerable<TEntity> Data { get; set; }

        public PaginatedItemsDto(int pageIndex , int pageSize , int count , IEnumerable<TEntity>  data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            count = count;
            Data = data;
        }
    }
}
