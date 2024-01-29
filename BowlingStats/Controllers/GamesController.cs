using AutoMapper;
using BowlingStats.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BowlingStats.Controllers
{
    public class GamesController : BaseController<GamesController>
    {
        private readonly IMapper _mapper;

        public GamesController(ILogger<GamesController> logger, IBowlingContext context, IMapper mapper) : base(logger, context) 
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int? page = 1)
        {
            int pageSize = 25;
            var games = _context.Games.Include(g => g.Scores).ThenInclude(s => s.Player).OrderByDescending(g => g.Date).ThenBy(g => g.Number);
            GamesViewModel model = new GamesViewModel()
            {
                Items = await games.ToPagedListAsync(page, pageSize)
            };

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            AddGameViewModel model = new AddGameViewModel();
            model.Date = HttpContext.Session.Get<DateTime?>(Constants.SessionKeys.LAST_ENTERED_DATE) ?? DateTime.Today;
            model.Number = (HttpContext.Session.GetInt32(Constants.SessionKeys.LAST_ENTERED_GAME_NUMBER) ?? 0) + 1;
            model.Scores.Add(new AddScoreViewModel());
            model.Scores.Add(new AddScoreViewModel());
            await InitAddGameViewModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                Game game = _mapper.Map<Game>(model);
                _context.Games.Add(game);

                await _context.SaveChangesAsync();
                _logger.LogInformation("New game added", game);
                HttpContext.Session.Set(Constants.SessionKeys.LAST_ENTERED_DATE, model.Date);
                HttpContext.Session.SetInt32(Constants.SessionKeys.LAST_ENTERED_GAME_NUMBER, model.Number);
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogInformation("Game failed validation");
                await InitAddGameViewModel(model);
                return View(model);
            }
        }

        private async Task InitAddGameViewModel(AddGameViewModel model)
        {
            model.Players = await _context.Players.Select(x => new SelectListItem(x.Name, x.PlayerId.ToString())).ToListAsync();
        }
    }
}
