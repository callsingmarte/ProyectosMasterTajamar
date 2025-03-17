using Microsoft.AspNetCore.Mvc;
using SegundoProyectoRedis;

public class HomeController : Controller
{
    private static IConfiguration _configuration;

    private RedisConnection _redisConnection;
    private Task<RedisConnection> _redisConnectionFactory;

    public HomeController(IConfiguration configuration)
    {
        //traemos la cadena de conexión desde el almacen de secretos
        //para inicializas la conexión a Redis
        _configuration = configuration;
        _redisConnectionFactory = RedisConnection.InitializeAsync(connectionString: _configuration["CacheConnection"]);
    }
    public ActionResult Index()
    {
        return View();
    }
    public async Task<ActionResult> RedisCache()
    {
        _redisConnection = await _redisConnectionFactory;
        ViewBag.Message = "A simple example with Azure Cache for Redis on ASP.NET.";

        // Perform cache operations using the cache object...

        // Simple PING command
        ViewBag.command1 = "PING";
        ViewBag.command1Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.ExecuteAsync("PING"))).ToString();

        string key = "Message";
        string value = "Hello! The cache is working from ASP.NET!";

        ViewBag.command2 = $"SET {key} \"{value}\"";
        ViewBag.command2Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringSetAsync(key, value))).ToString();

        ViewBag.command3 = $"GET {key}";
        ViewBag.command3Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringGetAsync(key))).ToString();

        key = "LastUpdateTime";
        value = DateTime.UtcNow.ToString();

        ViewBag.command4 = $"GET {key}";
        ViewBag.command4Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringGetAsync(key))).ToString();

        ViewBag.command5 = $"SET {key}";
        ViewBag.command5Result = (await _redisConnection.BasicRetryAsync(async (db) => await db.StringSetAsync(key, value))).ToString();


        return View();
    }
}