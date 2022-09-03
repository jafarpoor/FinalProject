using Application.Interfaces.Baskets;
using Application.Services;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSite.EndPoint.Models.ViewModels.Register;
using WebSite.EndPoint.Models.ViewModels.User;
using WebSite.EndPoint.Utilities;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Web;

namespace WebSite.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;
        private readonly IBasketService _basket;
        public AccountController(UserManager<User> userManager,
                                 SignInManager<User> signInManager , 
                                 RoleManager<IdentityRole> roleManager ,
                                 IBasketService basket)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = new EmailService();
            _smsService = new SmsService();
            _basket = basket;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            UserInfoDto userInfo = new UserInfoDto()
            {
              EmailConfirmed =user.EmailConfirmed,
              Email = user.Email,
              FullName = user.FullName,
              PhoneNumber=user.PhoneNumber,
              PhoneNumberConfirmed =user.PhoneNumberConfirmed ,
              TwoFactorEnabled =user.TwoFactorEnabled,
              UserName =user.UserName
            };
            return View(userInfo);
        }


        [Authorize]
        public IActionResult TwoFactorEnabled()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var Result = _userManager.SetTwoFactorEnabledAsync(user, !user.TwoFactorEnabled).Result;
            return RedirectToAction("Index");
        }


        public IActionResult Register()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

         //   var userRole = _roleManager.FindByNameAsync("Customer").Result;
          
            User newUser = new User()
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,  
            };
            var result = _userManager.CreateAsync(newUser, model.Password).Result;
           // var reultRole = _userManager.AddToRoleAsync(newUser ,userRole.Name).Result;
            if (result.Succeeded)
            {
                var Token = _userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
                var Link = Url.Action("ConfirmEmail", "Account", new { userID = newUser.Id, Token = Token }, protocol: Request.Scheme);

                string body = $"لطفا برای فعال حساب کاربری بر روی لینک زیر کلیک کنید!  <br/> <a href={Link}> Link </a>";
                _emailService.Execute(newUser.Email, body, "فعال سازی حساب کاربری باگتو");



                var user = _userManager.FindByNameAsync(newUser.Email).Result;
                TransferBasketForuser(user.Id);
                return RedirectToAction("DisplayEmail");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }

            string message = "";
            foreach (var item in result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;

            return View(model);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userManager.FindByNameAsync(model.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");

                return View(model);
            }
            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, model.Password
                , model.IsPersistent, true).Result;

            if (result.Succeeded)
            {
                TransferBasketForuser(user.Id);
                return Redirect(model.ReturnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("TwoFactorLogin", new { model.Email , model.IsPersistent });
            }

            return View();
        }

        public IActionResult TwoFactorLogin(string Email , bool IsPersistent)
        {
           var user = _userManager.FindByNameAsync(Email).Result;
            if (user == null)
            {
                return BadRequest();
            }
            var providerUser = _userManager.GetValidTwoFactorProvidersAsync(user).Result;
            TwoFactorLoginDto twoFactorLoginDto = new TwoFactorLoginDto();

            if (providerUser.Contains("Phone"))
            {
                var code = _userManager.GenerateTwoFactorTokenAsync(user, "Phone").Result;
        
                _smsService.Send(user.PhoneNumber , code);

                twoFactorLoginDto.Provider = "Phone";
                twoFactorLoginDto.IsPersistent = IsPersistent;

            }
            else if (providerUser.Contains("Email"))
            {
                var code = _userManager.GenerateTwoFactorTokenAsync(user, "Email").Result;
                _emailService.Execute(user.Email, "Code Two FactorLogin", "CodeValidetion");
                twoFactorLoginDto.Provider = "Email";
                twoFactorLoginDto.IsPersistent = IsPersistent;
            }
            return View(twoFactorLoginDto);
        }

        [HttpPost]
        public IActionResult TwoFactorLogin(TwoFactorLoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var user = _signInManager.GetTwoFactorAuthenticationUserAsync().Result;
            if (user == null)
            {
                return BadRequest();
            }

            var result = _signInManager.TwoFactorSignInAsync(dto.Provider, dto.Code, dto.IsPersistent, false).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "حساب کاربری شما قفل شده است");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "کد وارد شده صحیح نیست ");
                return View();
            }
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //AdduserRole For Admin
        public IActionResult AddUserRole(string Id)
        {
            var user = _userManager.FindByNameAsync(Id).Result;
            var Result = new List<SelectListItem>(
                _roleManager.Roles.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Name
                }).ToList()
            );
            return View(new AddUserRoleDto
            {
                Id = Id,
                Roles = Result ,
                Email= user.Email,
                UserName = user.UserName,

            });
        }

        [HttpPost]
        public IActionResult AddUserRole(AddUserRoleDto addUserRoleDto)
        {
            var user = _userManager.FindByNameAsync(addUserRoleDto.Id).Result;
            var Result = _userManager.AddToRoleAsync(user, addUserRoleDto.Role).Result;
            if (Result.Succeeded)           
                return RedirectToAction("UserRoles", "Account");

            return View(addUserRoleDto);            
        }


        //List Role For User
        public IActionResult UserRoles(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            var Result = _userManager.GetRolesAsync(user);
            return View(Result);
        }


        //list users each role
        public IActionResult UserInRole(string NameRole)
        {
            var Result = _userManager.GetUsersInRoleAsync(NameRole).Result;
            return View(Result.Select(p=> new UserListDto { 
                PhoneNumber = p.PhoneNumber,
                FirstName =p.FullName,
                UserName= p.UserName,
               EmailConfirmed =p.EmailConfirmed,
               AccessFailedCount = p.AccessFailedCount
            }));
        }

        public IActionResult ConfirmEmail(string userID , string Token)
        {
            User user=null;
           if (userID !=null)
               user = _userManager.FindByIdAsync(userID).Result;
            if (user == null || Token == null)
                return BadRequest();
            var Confirm = _userManager.ConfirmEmailAsync(user, Token).Result;
            if (Confirm.Succeeded)
                return RedirectToAction("Login", "Account");
            return View();
        }

        public IActionResult DisplayEmail()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordConfirmationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);

            }
            string message = "";
            var user = _userManager.FindByEmailAsync(dto.Email).Result;
            if(user == null || !_userManager.IsEmailConfirmedAsync(user).Result)
            {
                TempData["Message"] = "کاربر یافت نشد یا تایید ایمیل به درستی انجام نشده است";

                return View();
            }

            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            string link = Url.Action("RessetPassword", "Account", new
            {
                UserId = user.Id,
                token = token
            }, protocol: Request.Scheme);

            string body = $"برای تنظیم مجدد کلمه عبور بر روی لینک زیر کلیک کنید <br/> <a href={link}> link reset Password </a>";
            _emailService.Execute(user.Email, body, "تغییر رمز عبور");
            return RedirectToAction("SendLinkRestPassword" , "Account");
        }

        public IActionResult RessetPassword(string userId , string token)
        {

            return View(new ResetPasswordDto
            {
                Token =token,
                UserId=userId
            });
                    
        }

        [HttpPost]
        public IActionResult RessetPassword(ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = _userManager.FindByIdAsync(dto.UserId).Result;
            if (user == null)
                return BadRequest();

            var Result = _userManager.ResetPasswordAsync(user, dto.Token, dto.Password).Result;
            if (Result.Succeeded)
                return RedirectToAction("RessetPasswordConfrim", "Account");

            return View();
        }

        public IActionResult RessetPasswordConfrim()
        {
            return View();
        }

        public string SendLinkRestPassword()
        {
            return "لینک عوض کردن رمز عبور برای شما ارسال شده است";
        }

        [Authorize]
        public IActionResult SetPhoneNumber()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult SetPhoneNumber(SetPhoneNumberDto dto)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var setPhoneNumber = _userManager.SetPhoneNumberAsync(user , dto.PhoneNumber).Result;
            var token = _userManager.GenerateChangePhoneNumberTokenAsync(user, dto.PhoneNumber).Result;
            _smsService.Send(dto.PhoneNumber, token);
            TempData["PhoneNumber"] = dto.PhoneNumber;
            return RedirectToAction(nameof(VerifyPhoneNumber));
        }

        [Authorize]
        public IActionResult VerifyPhoneNumber()
        {
            return View(new VerifyPhoneNumberDto
            {
                PhoneNumber = TempData["PhoneNumber"].ToString()
            }) ;
        }
        [Authorize]
        [HttpPost]
        public IActionResult VerifyPhoneNumber(VerifyPhoneNumberDto verify)
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var result = _userManager.VerifyChangePhoneNumberTokenAsync(user, verify.Code, verify.PhoneNumber).Result;
            if(result == false)
            {
                ViewData["Message"] = $"کد وارد شده برای شماره {verify.PhoneNumber} اشتباه اشت";
                return View(verify);
            }
            else
            {
                user.PhoneNumberConfirmed = true;
                _userManager.UpdateAsync(user);
            }
            return View();
        }

        public string VerifySuccess()
        {
            return "با موفقیت وارد شدید";
        }


        private void TransferBasketForuser(string userId)
        {
            if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
            {
                var anonymousId = Request.Cookies[ClaimUtility.basketCookieName];
                _basket.TransferBasket(anonymousId, userId);
                Response.Cookies.Delete(ClaimUtility.basketCookieName);
            }
        }
    }
}
