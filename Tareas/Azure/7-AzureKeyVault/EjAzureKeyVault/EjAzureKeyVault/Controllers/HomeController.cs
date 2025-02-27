using System.Diagnostics;
using EjAzureKeyVault.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjAzureKeyVault.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["secreto"] = _configuration["MySecretKey"];
            ViewData["key"] = _configuration["MyEncryptionKey"];
            ViewData["cert"] = _configuration["MySSL"];

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
