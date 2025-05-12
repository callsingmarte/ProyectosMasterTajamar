using Microsoft.AspNetCore.Mvc;

namespace EcommerceBasicoAWS.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
