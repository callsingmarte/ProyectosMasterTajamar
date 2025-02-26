using Microsoft.AspNetCore.Mvc;

namespace ClienteOAuthEmpleados.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            return View();
        }


    }
}
