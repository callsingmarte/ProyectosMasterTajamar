using CosmosDBCategoriesAPI.Models;

namespace CosmosDBCategoriesAPI.ViewModels
{
    public class CategoryFormData
    {
        public Category? category { get; set; }
        public IFormFile? picture { get; set; }
    }
}
