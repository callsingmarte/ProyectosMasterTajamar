using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private readonly List<TodoItem> _items = new();
        public IEnumerable<TodoItem> GetAll() => _items;
        public TodoItem? GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

        public void Add(TodoItem item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Complete(int id)
        {
            var item = GetById(id);
            if (item != null) item.IsComplete = true;
        }
    }
}
