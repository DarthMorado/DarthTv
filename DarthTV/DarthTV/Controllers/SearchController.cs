using DarthTV.Models;
using DarthTV.Services;
using Microsoft.AspNetCore.Mvc;

namespace DarthTV.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITvService _tvService;
        

        public SearchController(ILogger<HomeController> logger,
            ITvService tvService)
        {
            _logger = logger;
            _tvService = tvService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string query)
        {
            var result = await _tvService.SearchAsync(query);
            var model = result.Select(x => new TvItemModel()
            {
                Entity = x
            });
            return View(model);
        }
    }
}
