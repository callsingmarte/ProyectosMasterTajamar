using Microsoft.AspNetCore.Mvc;

namespace PedidosBlazor.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
