using DarthTV.Models;
using DarthTV.Services;
using Microsoft.AspNetCore.Mvc;

namespace DarthTV.Controllers
{
    public class TvItemController : Controller
    {
        private readonly ITvService _tvService;

        public TvItemController(ITvService tvService)
        {
            _tvService = tvService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var item = await _tvService.GetById(id);
            var model = new TvItemModel()
            {
                Entity = item
            };
            return View(model);
        }
    }
}
