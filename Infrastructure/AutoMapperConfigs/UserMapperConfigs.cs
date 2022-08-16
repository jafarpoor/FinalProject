using Application.Dtos;
using AutoMapper;
using Domain.Order;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapperConfigs
{
   public class UserMapperConfigs :Profile
    {
        public UserMapperConfigs()
        {
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<AddUserAddressDto, UserAddress>();
            CreateMap<UserAddress, Address>();
        }
    }
}
