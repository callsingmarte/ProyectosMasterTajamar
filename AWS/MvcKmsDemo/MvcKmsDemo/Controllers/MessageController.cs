using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MvcKmsDemo.Data;
using MvcKmsDemo.Models;
using MvcKmsDemo.Services;

namespace MvcKmsDemo.Controllers
{
    public class MessageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly KmsService _kmsService;

        public MessageController(AppDbContext context, KmsService kms)
        {
            _context = context;
            _kmsService = kms;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _context.Messages.ToListAsync();
            var decrypted = new List<(Guid Id, string DecryptedText)>();

            foreach (var message in messages)
            {
                var text = await _kmsService.DecryptAsync(message.EncryptedText);
                decrypted.Add((message.Id, text));
            }

            return View(decrypted);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText)) return View();

            var encrypted = await _kmsService.EncryptAsync(plainText);

            var message = new Message { EncryptedText = encrypted };

            _context.Messages.Add(message);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
