using System;
using Bespereboiniki.Datalayer.Repositories;
using Bespereboiniki.Datalayer.Tables;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View(new UPS());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult PostBespereboinik([FromForm] UPS bespereboinikModel)
        {
            var id = upsRepository.AddUPS(bespereboinikModel);
            Console.WriteLine($"новый бесперебойник с id {id} создан {User}");
            return Redirect("Index");
        }
    }
}