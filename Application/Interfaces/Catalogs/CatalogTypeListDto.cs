using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Catalogs
{
  public class CatalogTypeListDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int SubTypeCount { get; set; }
    }
}
