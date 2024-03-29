﻿using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Users
{
    [Table("AspNetUsers")]
    [Auditable]
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
