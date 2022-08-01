using Application.Interfaces.Catalogs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Catalogs
{
   public interface IGetCatalogItemPDPService
    {
        GetCatalogItemPDPDto Execute(int Id);
    }
}
