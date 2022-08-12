using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Users
{
  public  interface IUserAddressService
    {
        List<UserAddressDto> GetAddress(string UserId);

        void AddnewAddress(AddUserAddressDto addUserAddressDto);
    }
}
