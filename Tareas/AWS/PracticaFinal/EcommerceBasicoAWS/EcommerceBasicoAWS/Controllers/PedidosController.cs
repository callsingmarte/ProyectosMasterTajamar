using Microsoft.AspNetCore.Mvc;

namespace EcommerceBasicoAWS.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
