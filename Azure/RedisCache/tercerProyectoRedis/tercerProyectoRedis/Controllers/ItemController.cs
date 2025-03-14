using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tercerProyectoRedis.Data;
using tercerProyectoRedis.Services;

namespace tercerProyectoRedis.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CacheService _cacheService;

        public ItemController(ApplicationDbContext context, CacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }


        public async Task<IActionResult> Index()
        {
            //Intentamos obtener los items de la cache Redis
            var cacheKey = "all_items";
            var items = await _cacheService.GetCacheAsyncList(cacheKey);

            if (items == null) 
            {
                //Falla al conectar con BD
                items = await _context.Items.ToListAsync();
                await _cacheService.SetCacheAsync(cacheKey, items);
            }            

            return View(items);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var cacheKey = $"item_{id}";
            var item = await _cacheService.GetCacheAsync(cacheKey);

            if (item == null) 
            {
                item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
                if (item == null) 
                {
                    return NotFound();
                }

                await _cacheService.SetCacheAsync(cacheKey, item);
            }

            return View(item);
        }
    }
}
