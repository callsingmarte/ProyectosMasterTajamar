using System.Diagnostics;
using Kinesis_Demo.Models;
using Kinesis_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinesis_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly KinesisService _kinesis;
        private static int _messageIndex = 1;

        public HomeController(KinesisService kinesis)
        {
            _kinesis = kinesis;
        }

        public async Task<IActionResult> Index()
        {
            //Envio un mensaje a Kinesis

            await _kinesis.SendMessageAsync("Hola desde ASP.Net");
            ViewBag.Message = "Mensaje enviado a Kinesis";

            return View();
        }

        public async Task<IActionResult> Read()
        {
            //Leer los mensajes y enviarlos a la vista correspondiente
            var messages = await _kinesis.ReadMessagesAsync();
            ViewBag.Messages = messages;
            return View();
        }

        public IActionResult Live()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetKinesisMessages()
        {
            //metodo de mensajes en json
            var messages = await _kinesis.ReadMessagesAsync(10);
            return Json(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                await _kinesis.SendMessageAsync(message);

                await _kinesis.SaveMessageToS3(message, _messageIndex);

                _messageIndex++;
            }

            //Obtener todos los mensajes incluyendo el nuevo
            var messages = await _kinesis.ReadMessagesAsync(10);

            return Json(messages);
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
