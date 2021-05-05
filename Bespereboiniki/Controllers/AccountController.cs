using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Bespereboiniki.Datalayer.Repositories;
using Bespereboiniki.Datalayer.Tables;
using Bespereboiniki.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Bespereboiniki.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly string homePage = "/";

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Login([FromQuery] string returnUrl)
        {
            return View(new UserModel() {ReturnUrl = returnUrl ?? homePage});
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel userModel)
        {
            var user = userRepository.GetUserByLogin(userModel.Login);

            if (user == null || user.Password != userModel.Password) return Redirect("/Account/AccessDenied");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, CreateClaims(user));
            return Redirect(userModel.ReturnUrl ?? homePage);
        }

        public IActionResult AccessDenied([FromQuery] string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl ?? homePage;
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Account/Login");
        }

        private ClaimsPrincipal CreateClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.UserRole.Name),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}