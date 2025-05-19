using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBasicoAWS.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            List<Categoria> categorias = await _categoriaService.GetCategorias();

            return View(categorias);
        }

        [HttpGet]
        public IActionResult AddCategoria()
        {
            return View("CreateOrUpdateCategoria");
        }

        [HttpPost]
        public IActionResult AddCategoria(Categoria categoria)
        {

            if (ModelState.IsValid) 
            {
                _categoriaService.AddCategoria(categoria);

                return RedirectToAction(nameof(Index));
            }

            return View("CreateOrUpdateCategoria");
        }

        [HttpGet]
        public IActionResult EditCategoria()
        {
            return View("CreateOrUpdateCategoria");
        }

        [HttpPost]
        public IActionResult EditCategoria(Guid idCategoria, Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                _categoriaService.UpdateCategoria(idCategoria, categoria);

                return RedirectToAction(nameof(Index));
            }

            return View("CreateOrUpdateCategoria");
        }

        [HttpPost]
        public IActionResult DeleteCategoria(Guid idCategoria) 
        {        
            _categoriaService.RemoveCategoria(idCategoria);

            return RedirectToAction(nameof(Index));
        }
    }
}
