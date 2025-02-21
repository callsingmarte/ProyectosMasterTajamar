using CosmosDBCategoriesAPI.Models;

namespace CosmosDBCategoriesAPI.Interfaces
{
    public interface ICategoryCosmosService
    {
        Task<List<Category>> GetCategories(string sqlCosmosQuery);
        Task<Category> GetCategory(string sqlCosmosQuery);
        Task<Category> Add(Category newCategory);
        Task<Category> Update(Category categoryToUpdate);
        Task Delete(string id);
    }
}
