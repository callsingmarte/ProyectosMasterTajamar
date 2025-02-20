using CarMakeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarMakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly ICarCosmosService _carCosmosService;

        public CarController(ICarCosmosService carCosmosService)
        {
            _carCosmosService = carCosmosService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlCosmosQuery = "SELECT * FROM c";
            var result = await _carCosmosService.GetCars(sqlCosmosQuery);
            return Ok(result);

        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car newCar)
        {
            newCar.Id = Guid.NewGuid().ToString();
            await _carCosmosService.AddCar(newCar); 
            return CreatedAtAction(nameof(Get), newCar.Id);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Car carToUpdate)
        {
            await _carCosmosService.UpdateCar(carToUpdate);
            return NoContent();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, string make)
        {
            await _carCosmosService.Delete(id, make);
            return NoContent();
        }
    }
}
