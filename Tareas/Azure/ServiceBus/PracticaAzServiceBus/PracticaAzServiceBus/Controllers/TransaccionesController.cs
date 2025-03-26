using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using PracticaAzServiceBus.Data;
using PracticaAzServiceBus.Models;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace PracticaAzServiceBus.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly string _queueName;
        private readonly string _topicName;
        private readonly string _subscriptionAudit;
        private readonly string _subscriptionNotification;
        private readonly string _connectionString;
        private readonly TransaccionDbContext _context;

        TransaccionesController(IConfiguration configuration, TransaccionDbContext context)
        {
            _connectionString = configuration["AzureServiceBus:ConnectionString"] != "" ? configuration["AzureServiceBus:ConnectionString"]! : Environment.GetEnvironmentVariable("AzureServiceBusConnectionString")!;
            _queueName = configuration["AzureServiceBus:QueueName"]!;
            _topicName = configuration["AzureServiceBus:TopicName"]!;
            _subscriptionAudit = configuration["AzureServiceBus:SubscriptionAudit"]!;
            _subscriptionNotification = configuration["AzureServiceBus:SubscriptionNotification"]!;
            _context = context;
        }

        /**
            * •	Módulo de Envío de Transacciones
            o	Formulario para ingresar monto, tipo de transacción (pago con tarjeta o transferencia), cuenta de destino, y detalles adicionales.
            o	Botón para enviar transacción a la cola.
         */

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTransaction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaccion transaccion)
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);

            
            ColaTransaccionesPendientes ultimaTransaccion =
            new ColaTransaccionesPendientes {
                TransaccionId = 0,
                Estado = "",
                Monto = 0,
                TipoTransaccion = ""
            };

            ServiceBusMessage busMessage = new ServiceBusMessage(JsonSerializer.Serialize(transaccion));

            await sender.SendMessageAsync(busMessage);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReceiveMessageFromQueue()
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);
            ServiceBusReceivedMessage busMessage = await receiver.ReceiveMessageAsync();
            string objetoJson = busMessage.Body.ToString();
            Transaccion transaccion = JsonSerializer.Deserialize<Transaccion>(objetoJson);

            ColaTransaccionesPendientes ultimaTransaccion =
            new ColaTransaccionesPendientes
            {
                TransaccionId = 0,
                Estado = "",
                Monto = 0,
                TipoTransaccion = ""
            };

            return Content(busMessage != null ? $"{transaccion.TransaccionId}" : "No messages");
        }

        public async Task<IActionResult> ReceiveMessageFromSubscription(string subscriptionName)
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_topicName, subscriptionName);
            ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
            return Content(message != null ? Encoding.UTF8.GetString(message.Body) : "No messages");
        }
    }
}
