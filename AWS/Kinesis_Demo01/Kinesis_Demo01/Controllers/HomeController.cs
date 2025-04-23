using System.Diagnostics;
using Kinesis_Demo01.Models;
using Kinesis_Demo01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinesis_Demo01.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly KinesisService _kinesis;
        private static int _messageIndex = 1;  // Contador estático para el índice

        public HomeController(KinesisService kinesis)
        {
            _kinesis = kinesis;
        }

        public async Task<IActionResult> Index()
        {
            //Este mensaje se envia a Kinesis siempre que la aplicacón entre en el "/"
            await _kinesis.SendMessageAsync("Hola desde ASP.NET MVC!");
            ViewBag.Message = "Mensaje enviado a Kinesis.";
            return View();
        }

        public async Task<IActionResult> Read()
        {
            //Método para leer mensaje y enviarlo a la vista
            var messages = await _kinesis.ReadMessagesAsync();
            ViewBag.Messages = messages;
            return View();
        }

        public IActionResult Live()
        {
            return View(); // Esto carga la vista Live.cshtml
        }

        [HttpGet]
        public async Task<IActionResult> GetKinesisMessages()
        {
            //Método para conseguir de Kinesis los mensajes en formato json
            var messages = await _kinesis.ReadMessagesAsync(10);
            return Json(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            Console.WriteLine("[Controller] Enviando mensaje a Kinesis...");
            //Método que envia un nuevo mensaje
            if (!string.IsNullOrEmpty(message))
            {
                await _kinesis.SendMessageAsync(message); // Enviamos el mensaje a Kinesis

                Console.WriteLine("[Controller] Enviando mensaje a S3...");
                _ = Task.Run(() => _kinesis.SaveMessageToS3(message, _messageIndex)); // Guardar mensaje en segundo plano
                _messageIndex++;
                Console.WriteLine("[Controller] Mensaje procesado completamente.");
                //await _kinesis.SendMessageAsync(message); // Enviamos el mensaje a Kinesis
                //await _kinesis.SaveMessageToS3(message, _messageIndex); // Guardar mensaje en S3

                //// Incrementamos el índice para el siguiente mensaje
                //_messageIndex++;
            }

            // Obtener los últimos mensajes después de enviar el nuevo
            var messages = await _kinesis.ReadMessagesAsync(10);
            Console.WriteLine("[Controller] Respondiendo mensajes a la vista.");
            return Json(messages); // Devolvemos los mensajes en formato JSON
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
