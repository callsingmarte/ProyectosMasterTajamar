using Microsoft.AspNetCore.Mvc;

namespace PracticaAzServiceBus.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly string _queueName;
        private readonly string _topicName;
        private readonly string _subscriptionName;
        private readonly string _connectionString;

        TransaccionesController(IConfiguration configuration)
        {
            _connectionString = configuration["AzureServiceBus:ConnectionString"] != "" ? configuration["AzureServiceBus:ConnectionString"]! : Environment.GetEnvironmentVariable("AzureServiceBusConnectionString")!;
            _queueName = configuration["AzureServiceBus:QueueName"]!;
            _topicName = configuration["AzureServiceBus:TopicName"]!;
            _subscriptionName = configuration["AzureServiceBus:SubscriptionName"]!;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
