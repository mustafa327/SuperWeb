using Microsoft.AspNetCore.Mvc;
using SuperWeb.Data;
using SuperWeb.Models;
using SuperWeb.Services;
using System.Diagnostics;

namespace SuperWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SuperDbContext _context;
        private readonly PostService postService;

        public HomeController(PostService post)
        {
            this.postService = postService;
            //_context = context;SuperDbContext context,
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
