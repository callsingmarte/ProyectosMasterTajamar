using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.Services;
using EcommerceBasicoAWS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBasicoAWS.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService; 

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index(ProductosViewModel productosVm)
        {
            ProductosViewModel vm = await _productoService.GetProductos(
                                            productosVm.SearchTypes, 
                                            productosVm.Filters, 
                                            productosVm.CurrentPage, 
                                            productosVm.ResultsPerPage);

            return View(vm);
        }

        [HttpGet]
        public IActionResult AddProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducto(Producto producto)
        {
            bool response = await _productoService.AddProducto(producto);

            if (response)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(producto);
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateProducto(Guid id)
        {
            Producto? producto = await _productoService.GetProducto(id);

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducto(Guid id, Producto producto)
        {
            bool response = await _productoService.UpdateProducto(id, producto);

            if (response)
            {
                TempData["Mensaje"] = "El producto se actualizo correctamente.";
                TempData["TipoMensaje"] = "success";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Mensaje"] = "Se ha producido un error al actualizar el producto.";
                TempData["TipoMensaje"] = "error";

                return View(producto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProducto(Guid id)
        {
            bool response = await _productoService.DeleteProducto(id);

            if (response)
            {
                TempData["Mensaje"] = "El producto se eliminó correctamente.";
                TempData["TipoMensaje"] = "success";
            }
            else
            {
                TempData["Mensaje"] = "Ocurrió un error al eliminar el producto.";
                TempData["TipoMensaje"] = "error";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
