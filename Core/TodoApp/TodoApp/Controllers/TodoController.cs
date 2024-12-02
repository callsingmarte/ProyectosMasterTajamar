using Microsoft.AspNetCore.Mvc;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            var items = _todoService.GetAll();
            return View(items);
        }

        [HttpPost]
        public IActionResult Add(string title)
        {
            if (!string.IsNullOrEmpty(title)) 
            { 
                _todoService.Add(new Models.TodoItem { Title = title });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            _todoService.Complete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
