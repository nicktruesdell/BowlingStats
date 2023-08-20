using BowlingStats.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingStats.Controllers
{
    public class PlayerController : BaseController<PlayerController>
    {
        public PlayerController(ILogger<PlayerController> logger, IBowlingContext context) : base(logger, context) { }

        public async Task<IActionResult> Index()
        {
            PlayersViewModel model = new PlayersViewModel();
            model.Items = await _context.Players.ToListAsync();
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Player player)
        {
            if (ModelState.IsValid) 
            { 
                _context.Players.Add(player);

                await _context.SaveChangesAsync();
                _logger.LogInformation("New player added", player);
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogInformation("Player failed validation");
                return View(player);
            }
        }
    }
}
