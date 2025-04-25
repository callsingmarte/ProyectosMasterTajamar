using LambdaShoppingListWebAPI.Models;

namespace LambdaShoppingListWebAPI.Services
{
    public interface IShoppingListService
    {
        Dictionary<string, int> GetItemsFromShoppingList();
        void AddItemToShoppingList(ShoppingListModel shoppingList);
        void RemoveItemFromShoppingList(string name);
    }
}
