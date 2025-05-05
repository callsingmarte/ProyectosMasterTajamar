using Microsoft.AspNetCore.Mvc;
using Publicaciones.Interfaces;
using Publicaciones.Models;
using Publicaciones.ViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Publicaciones.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    public class PublicacionesController : Controller
    {
        private IpublicacionesRepository _repository;

        public PublicacionesController(IpublicacionesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(SearchRequest searchRequest)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (searchRequest != null) 
            {
                var publicaciones = await _repository!.Find(searchRequest, userId);

                return View(new PublicacionViewModel
                {
                    Publicaciones = publicaciones,
                    ResultsType = ResultsType.Search
                });
            }
            else
            {
                var publicaciones = await _repository!.UserPublicaciones(userId);

                return View(publicaciones);
            }
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(PublicacionInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateOrUpdate", model);
                }

                await _repository.Add(model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOrUpdate", model);
            }
        }

        [HttpGet]
        [Route("Edit/{publicacionId}")]
        public async Task<IActionResult> Edit(Guid publicacionId)
        {
            Publicacion publicacion = await _repository!.Single(publicacionId);

            ViewBag.PublicacionId = publicacionId;

            return View("CreateOrUpdate", new PublicacionInputModel
            {
                Titulo = publicacion.Titulo,
                Contenido = publicacion.Contenido,
                InputType = InputType.Update
            });
        }

        [HttpPost]
        [Route("Edit/{publicacionId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid publicacionId, PublicacionInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)                 
                {
                    return View("CreateOrUpdate", model);
                }

                await _repository.Update(publicacionId, model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOrUpdate", model);
            }
        }

        [HttpPost]
        [Route("Delete/{publicacionId}")]
        public async Task<IActionResult> Delete(Guid publicacionId)
        {
            await _repository.Remove(publicacionId);
            return RedirectToAction(nameof(Index));
        }
    }
}
