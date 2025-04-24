using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticaKinesis.Models;
using PracticaKinesis.Services;

namespace PracticaKinesis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KinesisService _kinesisService;
        private readonly BucketService _bucketService;

        public HomeController(ILogger<HomeController> logger, KinesisService kinesisService, BucketService bucketService)
        {
            _logger = logger;
            _kinesisService = kinesisService;
            _bucketService = bucketService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DashBoard()
        {
            List<SensorEvent> data = await _kinesisService.ReadMessagesAsync();

            return View(data);
        }

        public async Task<IActionResult> GetSensorDataList()
        {
            List<SensorEvent> data = await _kinesisService.ReadMessagesAsync();

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessagesToBucket([FromBody] List<SensorEvent> data)
        {
            if (data == null || !data.Any())
            {
                return BadRequest("No data received.");
            }

            bool response = await _bucketService.SaveMessageListToS3(data);

            return Json(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
