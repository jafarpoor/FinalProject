using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Catalogs
{
  public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
}
