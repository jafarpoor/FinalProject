using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebSite.EndPoint.Models.ViewModels.User
{
    public class AddUserRoleDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
