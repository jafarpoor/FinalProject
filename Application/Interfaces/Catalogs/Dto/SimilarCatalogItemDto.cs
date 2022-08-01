using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Catalogs.Dto
{
   public class SimilarCatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
    }
}
