using Microsoft.AspNetCore.Mvc;

namespace EcommerceBasicoAWS.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
