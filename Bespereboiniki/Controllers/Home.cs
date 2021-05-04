using Bespereboiniki.Datalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bespereboiniki.Controllers
{
    public class Home : Controller
    {
        private readonly IUPSRepository upsRepository;

        public Home(IUPSRepository upsRepository)
        {
            this.upsRepository = upsRepository;
        }
        // GET
        public IActionResult Index()
        {
            var upses = upsRepository.GetUPSs(0,10);
            return View(upses);
        }
    }
}