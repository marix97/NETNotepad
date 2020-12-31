using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NETNotepad.Domain.Interfaces;
using NETNotepad.DomainModels;
using NETNotepad.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NETNotepad.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUser(model.Username, model.Password);

                if (!(user is null))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim("FullName", model.Username),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {

                        RedirectUri = "/Home/Index",

                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return Redirect("/Home/Index");
                }
            }

            return Redirect("/Account/Error");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    var user = _userService.GetUser(model.Username, model.Password);

                    if (user is null)
                    {
                        await _userService.RegisterUserAsync(_mapper.Map<UserModel>(model));
                        return Redirect("/Account/SuccessfulRegistration");
                    }
                }
            }

            return Redirect("/Account/Error");
        }

        [HttpGet]
        public IActionResult SuccessfulRegistration()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
