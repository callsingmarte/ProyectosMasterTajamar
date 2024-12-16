using Microsoft.AspNetCore.Mvc;

namespace Smith_Swimming_School.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
