using Application.Dtos;
using Application.Interfaces.Contexts;
using Application.Interfaces.Users;
using AutoMapper;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IDataBaseContext dataBaseContext;
        private readonly IMapper mapper;

        public UserAddressService(IDataBaseContext dataBaseContext , IMapper mapper)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
        }
        public void AddnewAddress(AddUserAddressDto addUserAddressDto)
        {
            var result = mapper.Map<UserAddress>(addUserAddressDto);
            dataBaseContext.userAddresses.Add(result);
            dataBaseContext.SaveChanges();
        }

        public List<UserAddressDto> GetAddress(string UserId)
        {
            var result = dataBaseContext.userAddresses.Where(p => p.UserId == UserId);
            var resultMapp = mapper.Map<List<UserAddressDto>>(result);
            return resultMapp;
        }
    }
}
