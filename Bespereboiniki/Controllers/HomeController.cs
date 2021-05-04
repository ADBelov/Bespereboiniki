using Bespereboiniki.Datalayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bespereboiniki.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUPSRepository upsRepository;

        
        public HomeController(IUPSRepository upsRepository)
        {
            this.upsRepository = upsRepository;
        }
        // GET
        [Authorize(Roles = "manager,admin")]
        public IActionResult Index()
        {
            var upses = upsRepository.GetUPSs(0,10);
            return View(upses);
        }
    }
}