using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PrimerProyectoCache.Models;

namespace PrimerProyectoCache.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly IDistributedCache _cache;

        public HomeController(IDistributedCache distributedCache)
        {
            _cache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {
            string cacheKey = "CurrentTime";
            string cachedTime = await _cache.GetStringAsync(cacheKey)!;

            if (string.IsNullOrEmpty(cachedTime))
            {
                cachedTime = DateTime.UtcNow.ToString("yyyy-MM-dd:hh:mm:ss");
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                await _cache.SetStringAsync(cacheKey, cachedTime, options);
            }

            ViewBag.CachedTime = cachedTime;

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
