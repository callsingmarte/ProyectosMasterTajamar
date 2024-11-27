using Microsoft.AspNetCore.Mvc;

namespace EjerciciosCore.Controllers
{
    public class MyLibraryController : Controller
    {
        static List<string> allBooks = new List<string> {
            "El quijote",
            "La celestina",
            "The Witcher"
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Book()
        {
            ViewData["Books"] = allBooks;
            return View();        
        }

        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult AddBook(string book)
        {
            allBooks.Add(book);
            return RedirectToAction("Book", "MyLibrary");
        }
    }
}
