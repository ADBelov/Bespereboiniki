using Bespereboiniki.Datalayer.Repositories;
using Bespereboiniki.Datalayer.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Bespereboiniki.Controllers
{
    public class AddController : Controller
    {
        private readonly IUPSRepository upsRepository;

        public AddController(IUPSRepository upsRepository)
        {
            this.upsRepository = upsRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View(new UPS());
        }

        [HttpPost]
        public IActionResult PostBespereboinik([FromForm] UPS bespereboinikModel)
        {
            upsRepository.AddUPS(bespereboinikModel);
            return Redirect("Index");
        }
    }
}