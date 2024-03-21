using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemoApplication.Constants;
using SignalRDemoApplication.Hubs;
using SignalRDemoApplication.Models;
using System.Diagnostics;

namespace SignalRDemoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DealthlyHallowHub> _deathlyHub;


        public HomeController(ILogger<HomeController> logger, IHubContext<DealthlyHallowHub> deathlyHub)
        {
            _logger = logger;
            _deathlyHub = deathlyHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (SD.DeathlyHallowRace.ContainsKey(type))
                SD.DeathlyHallowRace[type]++;
            await _deathlyHub.Clients.All.SendAsync("updateDealthlyHallowCount",
                SD.DeathlyHallowRace[SD.Cloak], SD.DeathlyHallowRace[SD.Stone], SD.DeathlyHallowRace[SD.Wand]);
            return Accepted();
        }

        public IActionResult Chat()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
