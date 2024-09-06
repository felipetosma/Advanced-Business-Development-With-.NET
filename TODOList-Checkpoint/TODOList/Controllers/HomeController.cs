using Microsoft.AspNetCore.Mvc;
using TODOList.Data;
using TODOList.Models;
using System.Diagnostics;

namespace TODOList.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(dbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allTodos = _context.TODOs.ToList(); // Acesso ao _context
            ViewData["AllTodos"] = allTodos;
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
