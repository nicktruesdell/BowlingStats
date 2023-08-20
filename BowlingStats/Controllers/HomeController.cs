using BowlingStats.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BowlingStats.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        

        public HomeController(ILogger<HomeController> logger, IBowlingContext context) : base(logger, context)
        {
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