using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public int? ParentCatalogTypeId { get; set; }

        public CatalogType ParentCatalogType { get; set; }

        public ICollection<CatalogType> ChaildcatalogTypes { get; set; }
    }
}
