using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Catalogs.Dto
{
   public class GetCatalogItemPDPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGrouping<string, PDPFeaturesDto>> Features { get; set; }
        public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }
    }
}
