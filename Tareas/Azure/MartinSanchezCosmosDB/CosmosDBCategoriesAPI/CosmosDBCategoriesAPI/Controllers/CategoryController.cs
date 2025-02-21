using CosmosDBCategoriesAPI.Interfaces;
using CosmosDBCategoriesAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmosDBCategoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryCosmosService _categoryCosmosService;

        public CategoryController(ICategoryCosmosService categoryCosmosService)
        {
            _categoryCosmosService = categoryCosmosService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlCosmosQuery = "SELECT * FROM c";
            var result = await _categoryCosmosService.GetCategories(sqlCosmosQuery);

            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sqlCosmosQuery = $"SELECT * FROM c WHERE categoryId = {id}";
            var result = await _categoryCosmosService.GetCategory(sqlCosmosQuery);

            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] Category newCategory)
        {
            newCategory.CategoryID = Guid.NewGuid().ToString();
            await _categoryCosmosService.Add(newCategory);
            return CreatedAtAction(nameof(Get), newCategory.CategoryID);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Put([FromBody] Category categoryToUpdate)
        {
            await _categoryCosmosService.Update(categoryToUpdate);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryCosmosService.Delete(id);
            return NoContent();
        }
    }
}
