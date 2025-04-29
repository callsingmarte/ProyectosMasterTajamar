using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaDynamoDb.Models;
using System.Threading.Tasks;

namespace PracticaDynamoDb.App.Controllers
{
    [Route("/[controller]")]
    public class SeriesController : Controller
    {
        private ISeriesRepository _repository;

        public SeriesController(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string titulo = "")
        {

            if (!string.IsNullOrEmpty(titulo)) 
            {
                var series = await _repository!.Find(new SearchRequest { Titulo = titulo });

                return View(new SerieViewModel
                {
                    Series = series,
                    ResultsType = ResultsType.Search
                });
            }
            else
            {
                var series = await _repository!.All();

                return View(series);
            }
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var disponibleEnSelect = new List<SelectListItem>()
            {
                new SelectListItem(){Text = DisponibleEn.PrimeVideo, Value = DisponibleEn.PrimeVideo},
                new SelectListItem(){Text = DisponibleEn.Netflix, Value = DisponibleEn.Netflix},
                new SelectListItem(){Text = DisponibleEn.HBO, Value = DisponibleEn.HBO},
                new SelectListItem(){Text = DisponibleEn.Crunchyroll, Value = DisponibleEn.Crunchyroll}
            };
            @ViewBag.DisponibleEn = disponibleEnSelect;
            return View("CreateOrUpdate");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(SerieInputModel model)
        {
            var disponibleEnSelect = new List<SelectListItem>()
            {
                new SelectListItem(){Text = DisponibleEn.PrimeVideo, Value = DisponibleEn.PrimeVideo},
                new SelectListItem(){Text = DisponibleEn.Netflix, Value = DisponibleEn.Netflix},
                new SelectListItem(){Text = DisponibleEn.HBO, Value = DisponibleEn.HBO},
                new SelectListItem(){Text = DisponibleEn.Crunchyroll, Value = DisponibleEn.Crunchyroll}
            };

            @ViewBag.DisponibleEn = disponibleEnSelect;

            try
            {
                if (!ModelState.IsValid) 
                {
                    return View("CreateOrUpdate", model);
                }

                await _repository.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOrUpdate", model);
            }
        }

        [HttpGet]
        [Route("Edit/{serieId}")]
        public async Task<IActionResult> Edit(string serieId)
        {
            var serie = await _repository!.Single(serieId);

            ViewBag.SerieId = serieId;

            var disponibleEnSelect = new List<SelectListItem>()
            {
                new SelectListItem(){Text = DisponibleEn.PrimeVideo, Value = DisponibleEn.PrimeVideo},
                new SelectListItem(){Text = DisponibleEn.Netflix, Value = DisponibleEn.Netflix},
                new SelectListItem(){Text = DisponibleEn.HBO, Value = DisponibleEn.HBO},
                new SelectListItem(){Text = DisponibleEn.Crunchyroll, Value = DisponibleEn.Crunchyroll}
            };
            @ViewBag.DisponibleEn = disponibleEnSelect;

            return View("CreateOrUpdate", new SerieInputModel
            {
                Titulo = serie.Titulo,
                Genero = serie.Genero,
                Temporadas = serie.Temporadas,
                DisponibleEn = serie.DisponibleEn
            });
        }

        [HttpPost]
        [Route("Edit/{serieId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string serieId, SerieInputModel model)
        {
            var disponibleEnSelect = new List<SelectListItem>()
            {
                new SelectListItem(){Text = DisponibleEn.PrimeVideo, Value = DisponibleEn.PrimeVideo},
                new SelectListItem(){Text = DisponibleEn.Netflix, Value = DisponibleEn.Netflix},
                new SelectListItem(){Text = DisponibleEn.HBO, Value = DisponibleEn.HBO},
                new SelectListItem(){Text = DisponibleEn.Crunchyroll, Value = DisponibleEn.Crunchyroll}
            };
            @ViewBag.DisponibleEn = disponibleEnSelect;

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateOrUpdate", model);
                }

                await _repository.Update(serieId, model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOrUpdate", model);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string serieId)
        {
            await _repository.Remove(serieId);
            return RedirectToAction(nameof(Index));
        }

    }
}
