using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        public int Id { get; set; }
    }
}
