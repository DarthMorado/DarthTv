using DarthTV.Models;
using DarthTV.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DarthTV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOmdbService _omdbService;

        public HomeController(ILogger<HomeController> logger,
            IOmdbService omdbService)
        {
            _logger = logger;
            _omdbService = omdbService;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Privacy()
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
