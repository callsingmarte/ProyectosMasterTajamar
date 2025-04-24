using DynamoDb.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DynamoDb.ReadersApp.Controllers
{
    [Route("/[controller]")]
    public class ReadersController : Controller
    {
        private IReadersRepository _repository;

        public ReadersController(IReadersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string userName = "")
        {
            if (!string.IsNullOrEmpty(userName)) 
            {
                var readers = await _repository!.Find(new SearchRequest {UserName = userName});

                return View(new ReaderViewModel
                {
                    Readers = readers,
                    ResultsType = ResultsType.Search
                });
            }
            else
            {
                var readers = await _repository!.All();

                return View(readers);
            }
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("~/Views/Readers/CreateOrUpdate.cshtml");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ReaderInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("~/Views/Readers/CreateOrUpdate.cshtml", model);
                }

                await _repository.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch {
                return View("~/Views/Readers/CreateOrUpdate.cshtml", model);
            }
        }

        [HttpGet]
        [Route("Edit/{readerId}")]
        public async Task<IActionResult> Edit(Guid readerId)
        {
            var reader = await _repository!.Single(readerId);

            ViewBag.ReaderId = readerId;

            return View("~/Views/Readers/CreateOrUpdate.cshtml", new ReaderInputModel {
                EmailAddress = reader.EmailAddress,
                Name = reader.Name,
                UserName = reader.Username,
                AddedOn = reader.AddedOn,
                InputType = InputType.Update
            });
        }

        [HttpPost]
        [Route("Edit/{readerId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid readerId, ReaderInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("~/Views/Readers/CreateOrUpdate.cshtml", model);
                }

                await _repository.Update(readerId, model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("~/Views/Readers/CreateOrUpdate.cshtml", model);
            }
        }

        [HttpGet]
        [Route("Delete/{readerId}")]
        public async Task<IActionResult> Delete(Guid readerId)
        {
            await _repository.Remove(readerId); 
            return RedirectToAction(nameof(Index));
        }
    }
}
