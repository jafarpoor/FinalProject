using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    [Auditable]
    public class UserAddress
    {
        public int Id { get; set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get; private set; }
        public string ReciverName { get; private set; }

        public UserAddress()
        {

        }

        public UserAddress(string State , string City , string ZipCode , string PostalAddress ,
                          string UserId , string ReciverName)
        {
            this.State = State;
            this.City = City;
            this.ZipCode = ZipCode;
            this.PostalAddress = PostalAddress;
            this.UserId = UserId;
            this.ReciverName = ReciverName;
        }
    }

}
