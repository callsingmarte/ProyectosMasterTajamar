using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Services;
using TodoApp.Models;
namespace TodoApp.Test
{
    public class TodoServiceTest
    {
        private readonly TodoService _Service;

        public TodoServiceTest()
        {
            _Service = new TodoService();
        }

        [Fact]
        public void Add_ShouldAddNewItem()
        {
            //Act
            _Service.Add(new TodoItem { Title = "Test Task" });
            //Asert
            var items = _Service.GetAll().ToList();
            Assert.Single(items);
            Assert.Equal("Error Task", items[0].Title);
            Assert.False(items[0].IsComplete);
        }

        [Fact]
        public void Complete_ShouldMarkItemAsComplete()
        {
            _Service.Add(new TodoItem { Title = "Test Task" });

            var item = _Service.GetById(1);
            Assert.NotNull(item);
            Assert.True(item.IsComplete);
        }
    }
}
