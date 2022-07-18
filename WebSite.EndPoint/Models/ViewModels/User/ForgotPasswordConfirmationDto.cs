using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewModels.User
{
    public class ForgotPasswordConfirmationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
