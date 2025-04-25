using LambdaShoppingListWebAPI.Models;
using LambdaShoppingListWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LambdaShoppingListWebAPI.Controllers
{
    [Route("v1/shoppingList")]
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService? _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet]
        public IActionResult GetShoppingList()
        {
            var result = _shoppingListService?.GetItemsFromShoppingList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddItemToShoppingList([FromBody] ShoppingListModel shoppingList)
        {
            _shoppingListService?.AddItemToShoppingList(shoppingList);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteItemsFromShoppingList([FromBody] ShoppingListModel shoppingList)
        {
            _shoppingListService?.RemoveItemFromShoppingList(shoppingList.Name!);
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
