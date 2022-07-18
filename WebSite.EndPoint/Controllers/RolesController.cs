using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebSite.EndPoint.Models.ViewModels.Roles;

namespace WebSite.EndPoint.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var Result = _roleManager.Roles.Select(p=>new RoleDto
            {
                Name = p.Name
            }).ToList();
            return View(Result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleDto roleDto)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = roleDto.Name
            };
            var Result = _roleManager.CreateAsync(identityRole).Result;
            if (!Result.Succeeded)
            {
                ModelState.AddModelError("","خطا در ثبت نقش جدید");
                return View(roleDto);
            }
            return RedirectToAction("Index" ,"Roles");
        }
    }
}
