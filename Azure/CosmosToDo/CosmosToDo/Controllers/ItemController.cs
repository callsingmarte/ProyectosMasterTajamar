using CosmosToDo.Models;
using CosmosToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmosToDo.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;

        public ItemController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }

        [ActionName("Create")]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Id, Category, Name, Description, Completed")] Item item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddItemAsync(item);
            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await _cosmosDbService.GetItemAsync(id);
            if (item == null) {
                return NotFound();
            }

            return View(item);
        }
        
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([Bind("Id, Category, Name, Description, Completed")] Item item)
        {
            if(item.Id != null)
            {
                if (ModelState.IsValid) 
                {
                    await _cosmosDbService.UpdateItemAsync(item.Id, item);
                    return RedirectToAction("Index");
                }
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync(string id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Item item = await _cosmosDbService.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<IActionResult> DetailAsync(string id)
        {
            return View(await _cosmosDbService.GetItemAsync(id));
        }

    }
}
