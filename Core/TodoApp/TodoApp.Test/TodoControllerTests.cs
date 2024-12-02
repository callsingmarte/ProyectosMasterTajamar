using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Services;
using TodoApp.Models;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Controllers;

namespace TodoApp.Test
{
    public class TodoControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewWithItems()
        {
            var service = new TodoService();
            service.Add(new TodoItem { Title = "Task 1" });
            var controller = new TodoController(service);

            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(result.Model);
            Assert.Single(model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Add_ShoudlRedirectToIndex()
        {
            var service = new TodoService();
            var controller = new TodoController(service);

            var result = controller.Add("Task 1") as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Single(service.GetAll());
        }
    }
}
