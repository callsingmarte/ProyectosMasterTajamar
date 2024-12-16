using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smith_Swimming_School.Data;
using Smith_Swimming_School.Models;
using X.PagedList.Extensions;

namespace Smith_Swimming_School.Controllers
{
    public class VisitorController : Controller
    {
        private readonly ApplicationDbContext? _db;

        public VisitorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Offers()
        {
            return View();
        }

        public IActionResult AddSwimmer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSwimmer(Swimmer swimmer)
        {
            _db!.Swimmers.Add(swimmer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Facilities()
        {
            return View();
        }
    }
}
