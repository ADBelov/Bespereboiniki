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

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Login([FromQuery] string returnUrl)
        {
            return View(new UserModel() {ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel userModel)
        {
            var user = userRepository.GetUserByLogin(userModel.Login);

            if (user == null || user.Password != userModel.Password) return Redirect("/Account/AccessDenied");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, CreateClaims(user));
            return Redirect(userModel.ReturnUrl ?? "/");
        }

        public IActionResult AccessDenied()
        {
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

            // var authProperties = new AuthenticationProperties
            // {
            //     //AllowRefresh = <bool>,
            //     // Refreshing the authentication session should be allowed.
            //
            //     //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            //     // The time at which the authentication ticket expires. A 
            //     // value set here overrides the ExpireTimeSpan option of 
            //     // CookieAuthenticationOptions set with AddCookie.
            //
            //     //IsPersistent = true,
            //     // Whether the authentication session is persisted across 
            //     // multiple requests. When used with cookies, controls
            //     // whether the cookie's lifetime is absolute (matching the
            //     // lifetime of the authentication ticket) or session-based.
            //
            //     //IssuedUtc = <DateTimeOffset>,
            //     // The time at which the authentication ticket was issued.
            //
            //     //RedirectUri = <string>
            //     // The full path or absolute URI to be used as an http 
            //     // redirect response value.
            // };

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}