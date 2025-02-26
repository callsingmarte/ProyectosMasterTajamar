using Microsoft.AspNetCore.Mvc;

namespace ClienteOAuthEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
