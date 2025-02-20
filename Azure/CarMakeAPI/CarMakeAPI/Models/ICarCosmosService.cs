namespace CarMakeAPI.Models
{
    public interface ICarCosmosService
    {
        Task<List<Car>> GetCars(string sqlCosmosQuery);
        Task<Car> AddCar(Car newCar);
        Task<Car> UpdateCar(Car carToUpdate);
        Task Delete(string id, string make);
    }
}
