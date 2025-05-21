using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.Services;
using EcommerceBasicoAWS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceBasicoAWS.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        public ProductosController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
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
        public async Task<IActionResult> AddProducto()
        {
            ProductoViewModel productoVm = new ProductoViewModel()
            {
                Producto = new Producto(),
                Action = Enums.ActionTypes.Create
            };

            ViewBag.CategoriasList = await GetCategoriasSelectList();

            return View("CreateOrUpdateProducto", productoVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddProducto(ProductoViewModel productoVm)
        {
            Producto producto = new Producto();
            producto = await _productoService.AddProducto(productoVm.Producto, productoVm.Files, productoVm.CategoriasIds);

            ViewBag.CategoriasList = await GetCategoriasSelectList();

            if (producto.IdProducto != Guid.Empty)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("CreateOrUpdateProducto", new ProductoViewModel()
                {
                    Producto = productoVm.Producto,
                    CategoriasIds = productoVm.CategoriasIds,
                    Action = Enums.ActionTypes.Create
                });
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateProducto(Guid idProducto)
        {
            ViewBag.CategoriasList = await GetCategoriasSelectList();
            Producto? producto = await _productoService.GetProducto(idProducto);
            List<Categoria> categorias = await _categoriaService.GetProductoCategorias(idProducto);

            return View("CreateOrUpdateProducto", new ProductoViewModel()
            {
                Producto = producto,
                Categorias = categorias,
                CategoriasIds = categorias.Select(c => c.IdCategoria.ToString()).ToList(),
                Action = Enums.ActionTypes.Update,                
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducto(Guid idProducto, ProductoViewModel productoVm)
        {
            bool response = await _productoService.UpdateProducto(idProducto, productoVm.Producto, productoVm.Files, productoVm.CategoriasIds);
            ViewBag.CategoriasList = await GetCategoriasSelectList();
            Producto? producto = await _productoService.GetProducto(idProducto);
            List<Categoria> categorias = await _categoriaService.GetProductoCategorias(idProducto);

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

                return View("CreateOrUpdateProducto", new ProductoViewModel()
                {
                    Producto = producto,
                    Categorias = categorias,
                    CategoriasIds = categorias.Select(c => c.IdCategoria.ToString()).ToList(),
                    Action = Enums.ActionTypes.Update,
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProducto(Guid idProducto)
        {
            bool response = await _productoService.DeleteProducto(idProducto);

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

        private async Task<SelectList> GetCategoriasSelectList()
        {
            List<Categoria> categorias = await _categoriaService.GetCategorias();

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (Categoria categoria in categorias)
            {
                items.Add(new SelectListItem() { Text = categoria.Nombre, Value = categoria.IdCategoria.ToString() });
            }

            return new SelectList(items, "Value", "Text");
        }
    }
}
