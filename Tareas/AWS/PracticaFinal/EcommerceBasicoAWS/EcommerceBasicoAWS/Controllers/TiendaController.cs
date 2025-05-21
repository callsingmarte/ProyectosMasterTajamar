using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Services;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EcommerceBasicoAWS.Controllers
{
    public class TiendaController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;
        private readonly ICarritoService _carritoService;

        public TiendaController(IProductoService productoService, ICategoriaService categoriaService, ICarritoService carritoService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
            _carritoService = carritoService;
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

        public async Task<IActionResult> DetallesProducto(Guid idProducto)
        {
            Producto? producto = await _productoService.GetProducto(idProducto);
            List<Categoria> categorias = await _categoriaService.GetProductoCategorias(idProducto);

            ProductoCategoriasDetallesViewModel vm = new ProductoCategoriasDetallesViewModel()
            {
                Producto = producto,
                Categorias = categorias,
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarrito()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Carrito? carrito = await _carritoService.GetUserCarrito(userId);

            return PartialView("_CarritoPartial", carrito);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarritoItem(Guid idProducto, int cantidad, string productoMainImageUrl)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Producto? producto = await _productoService.GetProducto(idProducto);

            if (producto != null) {
                ItemCarrito itemCarrito = new ItemCarrito()
                {
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    FechaCreacion = DateTime.Now,
                    PrecioUnitario = producto.Precio,
                    Subtotal = producto.Precio * cantidad,
                    MainImageUrl = productoMainImageUrl,                                        
                };
                Carrito carrito = await _carritoService.CreateOrAddUserCarrito(userId, itemCarrito);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCarritoItem(Guid idItemCarrito)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool response = await _carritoService.RemoveItemCarrito(userId, idItemCarrito);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ClearCarritoItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool response = await _carritoService.ClearCarritoItems(userId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserCarrito()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool response = await _carritoService.DeleteUserCarrito(userId);

            return Ok(response);
        }

        public async Task<IActionResult> PedidoDetalles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPedido()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CancelPedido()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
