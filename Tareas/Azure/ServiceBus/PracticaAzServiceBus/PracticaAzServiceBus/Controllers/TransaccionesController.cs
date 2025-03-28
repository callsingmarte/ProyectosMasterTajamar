using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using PracticaAzServiceBus.Data;
using PracticaAzServiceBus.Models;
using System.Text;
using System.Text.Json;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public IActionResult Auditoria()
        {
            return View();
        }


        public IActionResult AddTransaction()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransaction([Bind(
            "TransaccionId", "Monto", "TipoTransaccion", "CuentaDestino", "DetallesAdicionales",
            "Estado", "FechaCreacion", "FechaProcesamiento", "FechaNotificacion"
            )] Transaccion transaccion)
        {
            await _context.AddAsync(transaccion);
            _context.SaveChanges();

            sendMessagesToTopic(transaccion);

            return View("TransactionResult", true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransactionToQueue(
            [Bind(
            "TransaccionId", "Monto", "TipoTransaccion", "CuentaDestino", "DetallesAdicionales",
            "Estado", "FechaCreacion", "FechaProcesamiento", "FechaNotificacion"
            )] Transaccion transaccion)
        {
            //Añade la transaccion a la cola
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);            
            /*
            ColaTransaccionesPendientes ultimaTransaccion =
            new ColaTransaccionesPendientes {
                Estado = transaccion.Estado,
                Monto = transaccion.Monto,
                TipoTransaccion = transaccion.TipoTransaccion
            };
            */
            ServiceBusMessage busMessage = new ServiceBusMessage(JsonSerializer.Serialize(transaccion));
            await sender.SendMessageAsync(busMessage);

            sendMessagesToTopic(transaccion, "Auditoria");

            return RedirectToAction("ProcessTransaction");
        }

        public async Task<IActionResult> ProcessTransaction()
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);
            ServiceBusReceivedMessage busMessage = await receiver.ReceiveMessageAsync();
            if (busMessage != null) {
                string objetoJson = busMessage.Body.ToString();
                Transaccion transaccion = JsonSerializer.Deserialize<Transaccion>(objetoJson)!;
                return View(transaccion);
            }

            return View();
        }

        //Recupera mensajes de la cola
        public async Task<IActionResult> ReceiveMessagesFromQueue()
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 10);
            List<Transaccion> transacciones = [];
            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string objetoJson = receivedMessage.Body.ToString();
                transacciones.Add(JsonSerializer.Deserialize<Transaccion>(objetoJson)!);                
            }

            return Ok(transacciones);
        }

        public async Task<IActionResult> ReceiveMessageFromSubscription(string subscriptionName)
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_topicName, subscriptionName);
            ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
            return Content(message != null ? Encoding.UTF8.GetString(message.Body) : "No messages");
        }

        private async void sendMessagesToTopic(Transaccion transaccion, string subscription = "")
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_topicName);
            ServiceBusMessage busMessage = new ServiceBusMessage(JsonSerializer.Serialize(transaccion));

            if (!string.IsNullOrEmpty(subscription))
            {
                busMessage.ApplicationProperties["SubscriptionType"] = subscription;
            }

            await sender.SendMessageAsync(busMessage);
        }
    }
}
