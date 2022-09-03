using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Contexts
{
   public interface IIdentityDatabaseContext
    {
        DbSet<User> Users { get; set; }
    }
}
