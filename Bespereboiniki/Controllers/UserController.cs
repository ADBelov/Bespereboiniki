using Bespereboiniki.Datalayer.Repositories;
using Bespereboiniki.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bespereboiniki.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var users = userRepository.GetUsers(0, 100);

            return View(new UserPageDto
            {
                UserList = users
            });
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}