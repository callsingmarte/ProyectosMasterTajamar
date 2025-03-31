using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PracticaAzServiceBus.Data;
using PracticaAzServiceBus.Interfaces;
using PracticaAzServiceBus.Migrations;
using PracticaAzServiceBus.Models;
using PracticaAzServiceBus.ViewModels;
using System.Text;
using System.Text.Json;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PracticaAzServiceBus.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly TransaccionDbContext _context;
        private readonly string _queueName;
        private readonly string _topicName;
        private readonly string _connectionString;
        private readonly string _subscriptionAudit;
        private readonly string _subscriptionNotification;
        private readonly HttpClient _httpClient;


        public TransaccionesController(TransaccionDbContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _connectionString = configuration["AzureServiceBus:ConnectionString"] != "" ? configuration["AzureServiceBus:ConnectionString"]! : Environment.GetEnvironmentVariable("AzureServiceBusConnectionString")!;
            _queueName = configuration["AzureServiceBus:QueueName"]!;
            _topicName = configuration["AzureServiceBus:TopicName"]!;
            _subscriptionAudit = configuration["AzureServiceBus:SubscriptionAudit"]!;
            _subscriptionNotification = configuration["AzureServiceBus:SubscriptionNotification"]!;
            _httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> TransaccionesPendientes()
        {
            List<Transaccion> transacciones = await ReceiveMessagesFromQueue();

            return View(transacciones);
        }

        public async Task<IActionResult> Auditoria()
        {
            List<Transaccion> transacciones = [];
            List<Transaccion> transaccionesPorNotificar = [];
            transacciones = await ReceiveMessageFromSubscription(_subscriptionAudit);
            transaccionesPorNotificar = await ReceiveMessageFromSubscription(_subscriptionNotification);

            AuditoriaNotificacionesViewModel viewModel = new AuditoriaNotificacionesViewModel
            {
                Transacciones = transacciones,
                TransaccionesPorNotificar = transaccionesPorNotificar
            };

            return View(viewModel);
        }

        public IActionResult AddTransaction()
        {
            ViewBag.TiposTransaccion = new List<SelectListItem>
            {
                new SelectListItem { Value = ITiposTransaccion.TRANSFERENCIA_BANCARIA, Text = ITiposTransaccion.TRANSFERENCIA_BANCARIA },
                new SelectListItem { Value = ITiposTransaccion.PAGO_TARJETA, Text = ITiposTransaccion.PAGO_TARJETA },
            };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] Transaccion transaccion)
        {
            await _context.AddAsync(transaccion);
            _context.SaveChanges();

            return Json(new { redirectUrl = Url.Action("TransactionResult", transaccion) });
        }

        public async Task<IActionResult> TransactionResult(Transaccion transaccionPrev)
        {
            Transaccion transaccion = await _context.Transacciones
                .OrderByDescending(t => t.TransaccionId)
                .FirstOrDefaultAsync();

            EventoTransaccion eventoTransaccion = new EventoTransaccion();
            if (transaccion != null)
            {
                eventoTransaccion = new EventoTransaccion
                {
                    TransaccionId = transaccion.TransaccionId,
                    TipoEvento = "Transaccion aprobada",
                    FechaEvento = DateTime.Now,
                    Descripcion = $"Se ha realizado una transaccion por valor de {transaccion.Monto }" +
                    $" de tipo {transaccion.TipoTransaccion} " +
                    $"a la cuenta {transaccion.CuentaDestino} con exito"
                };
                transaccion.Estado = "Exitosa";
                transaccion.FechaProcesamiento = DateTime.Now;
                _context.Update(transaccion);
                sendMessagesToTopic(transaccion);
            }
            else
            {
                eventoTransaccion = new EventoTransaccion
                {
                    TipoEvento = "Transaccion fallida",
                    FechaEvento = DateTime.Now,
                    Descripcion = $"La transaccion de tipo {transaccionPrev.TipoTransaccion} " +
                    $"a la cuenta {transaccionPrev.CuentaDestino}, por valor de {transaccionPrev.Monto} a fallado "
                };
            }

            await _context.AddAsync(eventoTransaccion);
            _context.SaveChanges();

            return View(transaccion);
        }

        [HttpPost]
        public async Task<IActionResult> sendNotification(int transaccionId, string emailCliente)
        {

            Transaccion transaccion = await _context.Transacciones.FirstOrDefaultAsync(t => t.TransaccionId == transaccionId);

            string status = "";

            if (transaccion != null)
            {
               status = await callLogicAppSendEmail(transaccion, emailCliente);
            }

            return View("NotificationStatus", status);
        }

        private async Task<string> callLogicAppSendEmail(Transaccion transaccion, string emailCliente)
        {
            string logicAppUrl = "https://prod-83.westeurope.logic.azure.com:443/workflows/c329b81a435f4bcdbee83963ad01a4e4/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=1.0&sig=YsCTl8Int2XdvDlUh6UPpVzmAiZ9WspPpZ0vzK8-7Qs";

            string jsonData = JsonSerializer.Serialize(new
            {
                Monto = transaccion.Monto,
                CuentaDestino = transaccion.CuentaDestino,
                EmailCliente = emailCliente
            });
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(logicAppUrl, content);

            Notificacion notificacion = new Notificacion
            {
                TransaccionId = transaccion.TransaccionId,
                EmailCliente = emailCliente,
                EstadoNotificacion = IEstadosNotificacion.ENVIADA,
                FechaEnvio = DateTime.Now
            };

            if (!response.IsSuccessStatusCode)
            {
                notificacion = new Notificacion
                {
                    TransaccionId = transaccion.TransaccionId,
                    EmailCliente = emailCliente,
                    EstadoNotificacion = IEstadosNotificacion.FALLIDA,
                    FechaEnvio = DateTime.Now
                };
            }
            await _context.AddAsync(notificacion);
            transaccion.FechaNotificacion = DateTime.Now;
            _context.Update(transaccion);
            _context.SaveChanges();

            sendMessagesToTopic(transaccion);

            return notificacion.EstadoNotificacion;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransactionToQueue(
            [Bind(
            "TransaccionId", "Monto", "TipoTransaccion", "CuentaDestino", "DetallesAdicionales",
            "Estado", "FechaCreacion", "FechaProcesamiento", "FechaNotificacion"
            )] Transaccion transaccion)
        {

            if (ModelState.IsValid)
            {
                transaccion.Estado = IEstadosTransaccion.PENDIENTE;
                transaccion.FechaCreacion = DateTime.Now;
                //Añade la transaccion a la cola
                await using var client = new ServiceBusClient(_connectionString);
                ServiceBusSender sender = client.CreateSender(_queueName);
                ServiceBusMessage busMessage = new ServiceBusMessage(JsonSerializer.Serialize(transaccion));
                await sender.SendMessageAsync(busMessage);

                sendMessagesToTopic(transaccion, _subscriptionAudit);

                return RedirectToAction("ProcessTransaction");
            }

            return RedirectToAction("AddTransaction");

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
        private async Task<List<Transaccion>> ReceiveMessagesFromQueue()
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

            return transacciones;
        }

        private async Task<List<Transaccion>> ReceiveMessageFromSubscription(string subscriptionName)
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_topicName, subscriptionName);
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 10);
            List<Transaccion> transacciones = [];
            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string objetoJson = receivedMessage.Body.ToString();
                transacciones.Add(JsonSerializer.Deserialize<Transaccion>(objetoJson)!);
            }

            return transacciones;
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

        [HttpPost]
        public async Task<IActionResult> deleteMessagesFromSubscription(string subscription)
        {
            ServiceBusClient client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_topicName, subscription);

            while (true)
            {
                ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
                if (message == null)
                {
                    // No hay más mensajes en la suscripción
                    break;
                }

                // Completa el mensaje (lo elimina de la suscripción)
                await receiver.CompleteMessageAsync(message);
            }

            await receiver.CloseAsync();
            await client.DisposeAsync();

            return RedirectToAction("Auditoria");
        }

        [HttpPost]
        public async Task<IActionResult> deleteMessagesFromQueue()
        {
            await using ServiceBusClient client = new ServiceBusClient(_connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);

            while (true)
            {
                ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
                if (message == null) break; 

                await receiver.CompleteMessageAsync(message);
            }

            await receiver.CloseAsync();
            return RedirectToAction("TransaccionesPendientes");
        }

    }
}
