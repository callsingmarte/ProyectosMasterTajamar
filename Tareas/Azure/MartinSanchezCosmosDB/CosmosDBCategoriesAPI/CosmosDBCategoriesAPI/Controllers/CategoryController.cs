using CosmosDBCategoriesAPI.Interfaces;
using CosmosDBCategoriesAPI.Models;
using CosmosDBCategoriesAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmosDBCategoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryCosmosService _categoryCosmosService;
        private readonly IBlobService _blobService;

        public CategoryController(ICategoryCosmosService categoryCosmosService, IBlobService blobService)
        {
            _categoryCosmosService = categoryCosmosService;
            _blobService = blobService;
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
        public async Task<IActionResult> Get(string id, string categoryID)
        {
            var result = await _categoryCosmosService.GetCategory(id, categoryID);

            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryFormData formData)
        {
            Category newCategory = formData.category!;
            IFormFile? picture = formData.picture;

            if (picture != null && picture.Length > 0)
            {
                var stream = picture.OpenReadStream();
                string fileName = $"{newCategory.CategoryName}_{Guid.NewGuid()}_{picture.FileName}";

                bool uploadSuccess = await _blobService.UploadFile(stream, fileName);

                if (uploadSuccess)
                {
                    newCategory.Picture = await _blobService.GetPictureUrl(fileName);
                }
            }

            newCategory.id = Guid.NewGuid().ToString();
            newCategory.CategoryID = Guid.NewGuid().ToString();
            await _categoryCosmosService.Add(newCategory);
            return CreatedAtAction(nameof(Get), newCategory.CategoryID);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromForm] CategoryFormData formData)
        {

            Category categoryToUpdate = formData.category!;
            IFormFile? picture = formData.picture;

            if (picture != null && picture.Length > 0)
            {
                var stream = picture.OpenReadStream();
                string fileName = $"{categoryToUpdate.CategoryName}_{Guid.NewGuid()}_{picture.FileName}";

                bool uploadSuccess = await _blobService.UploadFile(stream, fileName);

                if (uploadSuccess)
                {
                    categoryToUpdate.Picture = await _blobService.GetPictureUrl(fileName);
                }
            }

            await _categoryCosmosService.Update(categoryToUpdate);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, string categoryID)
        {
            await _categoryCosmosService.Delete(id, categoryID);
            return NoContent();
        }
    }
}
