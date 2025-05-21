using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.ViewModels;
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
            return View("CreateOrUpdateCategoria", new CategoriaViewModel()
            {
                Categoria = new Categoria(),
                Action = Enums.ActionTypes.Create
            }
);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria(Categoria categoria)
        {

            if (ModelState.IsValid) 
            {
                await _categoriaService.AddCategoria(categoria);

                return RedirectToAction(nameof(Index));
            }

            return View("CreateOrUpdateCategoria", new CategoriaViewModel()
            {
                Categoria = categoria,
                Action = Enums.ActionTypes.Create
            }
);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategoria(Guid idCategoria)
        {
            Categoria? categoria = await _categoriaService.GetCategoria(idCategoria);

            return View("CreateOrUpdateCategoria", new CategoriaViewModel()
            {
                Categoria = categoria,
                Action = Enums.ActionTypes.Update
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditCategoria(Guid idCategoria, Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                bool response = await _categoriaService.UpdateCategoria(idCategoria, categoria);

                if (!response)
                {
                    return View("CreateOrUpdateCategoria", new CategoriaViewModel()
                    {
                        Categoria = categoria,
                        Action = Enums.ActionTypes.Update
                    });
                }

                return RedirectToAction(nameof(Index));
            }

            return View("CreateOrUpdateCategoria", new CategoriaViewModel()
            {
                Categoria = categoria,
                Action = Enums.ActionTypes.Update
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategoria(Guid idCategoria) 
        {        
            await _categoriaService.RemoveCategoria(idCategoria);

            return RedirectToAction(nameof(Index));
        }
    }
}
