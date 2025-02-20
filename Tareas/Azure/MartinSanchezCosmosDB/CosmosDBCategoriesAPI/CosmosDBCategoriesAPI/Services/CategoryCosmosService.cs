using CosmosDBCategoriesAPI.Interfaces;
using CosmosDBCategoriesAPI.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosDBCategoriesAPI.Services
{
    public class CategoryCosmosService : ICategoryCosmosService
    {
        private readonly Container _container;

        public CategoryCosmosService(CosmosClient cosmosDbClient, string databaseName, string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }

        public Task<Category> Add(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id, string make)
        {
            throw new NotImplementedException();
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

        public Task<Category> GetCategory(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Category>(new QueryDefinition(sqlCosmosQuery));
            //TODO
            return null;
        }

        public Task<Category> Update(Category categoryToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
