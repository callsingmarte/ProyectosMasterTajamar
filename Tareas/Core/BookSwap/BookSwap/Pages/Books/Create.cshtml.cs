using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookSwap.Data;
using BookSwap.Models;

namespace BookSwap.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookSwap.Data.BookSwapContext _context;

        public CreateModel(BookSwap.Data.BookSwapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!Book.IsAvailable)
            {
                Book.LoanDate = DateTime.Now;
                Book.ReturnDate = DateTime.Now.AddDays(7);
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
