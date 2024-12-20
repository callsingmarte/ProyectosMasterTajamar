using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smith_Swimming_School.Data;
using Smith_Swimming_School.Models;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace Smith_Swimming_School.Controllers
{
    [Authorize(Roles = "Visitor")]
    public class VisitorController : Controller
    {
        private readonly ApplicationDbContext? _context;

        public VisitorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Offers()
        {
            return View();
        }

        public async Task<IActionResult> AddSwimmer()
        {
            var userData = await _context!.Users.SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);

            Swimmer swimmer = new Swimmer
            {
                SwimmerUser = userData.UserName
            };

            ViewBag.GenreList = new SelectList(Enum.GetValues(typeof(Genre)).Cast<Genre>()
            .Select(g => new { Value = (int)g, Text = g.ToString() }), "Value", "Text");

            return View(swimmer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSwimmer([Bind("Id_Swimmer,Name,Phone_Number,SwimmerUser,Genre,Birth_Date")] Swimmer swimmer)
        {
            var userData = await _context!.Users.SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);

            //Comprobamos si ya es un swimmer
            var swimmerRegistered = await _context!.Swimmers.SingleOrDefaultAsync(s => s.SwimmerUser == User.Identity.Name);

            if (swimmerRegistered != null)
            {
                return View("SwimmerRegistered");
            }

            //Eliminamos El rol que tenia antes el usuario
            var userRole = await _context!.UserRoles.SingleOrDefaultAsync(u => u.UserId == userData.Id);
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();

            //Añadimos un nuevo swimmer
            _context!.Swimmers.Add(swimmer);

            //Añadimos el nuevo rol al usuario que pasa de visitor a Swimmer
            IdentityUserRole<string> newUserRole = new IdentityUserRole<string>
            {
                UserId = userData.Id,
                RoleId = _context.Roles.Single(r => r.Name == "Swimmer").Id
            };

            _context.UserRoles.Add(newUserRole);
            await _context.SaveChangesAsync();

            return View("SwimmerRegisteredSuccess");
        }

        public IActionResult Facilities()
        {
            return View();
        }
    }
}
