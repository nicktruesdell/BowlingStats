using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BowlingStats.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;
        protected readonly IBowlingContext _context;

        protected BaseController(ILogger<T> logger, IBowlingContext context)
        {
            _context = context;
            _logger = logger;
        }
    }
}
