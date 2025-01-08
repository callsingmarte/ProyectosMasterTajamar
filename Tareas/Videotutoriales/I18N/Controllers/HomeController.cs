using System.Diagnostics;
using I18N.Data;
using I18N.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace I18N.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext? _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, 
            IStringLocalizer<HomeController> localizer, 
            ApplicationDbContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["message"] = _localizer["welcome_message"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddContact() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> AddContact([Bind("Id,Name,Email,Phone,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();

                return View("ContactAdded", contact);
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
