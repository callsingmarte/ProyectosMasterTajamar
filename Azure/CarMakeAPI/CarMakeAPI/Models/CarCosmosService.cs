
using Microsoft.Azure.Cosmos;

namespace CarMakeAPI.Models
{
    public class CarCosmosService : ICarCosmosService
    {
        private readonly Container _container;

        public CarCosmosService(CosmosClient cosmosDbClient, string databaseName, string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }

        public async Task<Car> AddCar(Car newCar)
        {
            var item = await _container.CreateItemAsync(newCar, new PartitionKey(newCar.Make));
            return item;
        }

        public async Task Delete(string id, string make)
        {
            await _container.DeleteItemAsync<Car>(id, new PartitionKey(make));
        }

        public async Task<List<Car>> GetCars(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Car>(new QueryDefinition(sqlCosmosQuery));
            List<Car> result = new List<Car>();
            while (query.HasMoreResults) 
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response);
            }

            return result;
        }

        public async Task<Car> UpdateCar(Car carToUpdate)
        {
            var item = await _container.UpsertItemAsync(carToUpdate, new PartitionKey(carToUpdate.Make));
            return item;
        }
    }
}
