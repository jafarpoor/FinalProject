using Application.Interfaces.GetMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetMenuItem
{
  public interface IGetMenuItemService
    {
        List<MenuItemDto> Execute();
    }
}
