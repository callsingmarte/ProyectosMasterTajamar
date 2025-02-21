using CosmosDBCategoriesAPI.Interfaces;
using CosmosDBCategoriesAPI.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;

namespace CosmosDBCategoriesAPI.Services
{
    public class CategoryCosmosService : ICategoryCosmosService
    {
        private readonly Container _container;

        public CategoryCosmosService(CosmosClient cosmosDbClient, string databaseName, string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }

        public async Task<Category> Add(Category newCategory)
        {
            var item = await _container.CreateItemAsync(newCategory, new PartitionKey(newCategory.CategoryID));
            return item;
        }

        public async Task Delete(string id)
        {
            await _container.DeleteItemAsync<Category>(id, new PartitionKey(id));
        }

        public async Task<List<Category>> GetCategories(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Category>(new QueryDefinition(sqlCosmosQuery));
            List<Category> result = new List<Category>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response);
            }

            return result;
        }

        public async Task<Category> GetCategory(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Category>(new QueryDefinition(sqlCosmosQuery));
            Category? result = new Category();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result = response.FirstOrDefault();
            }

            return result;
        }

        public async Task<Category> Update(Category categoryToUpdate)
        {
            var item = await _container.UpsertItemAsync(categoryToUpdate, new PartitionKey(categoryToUpdate.CategoryID));
            return item;
        }
    }
}
