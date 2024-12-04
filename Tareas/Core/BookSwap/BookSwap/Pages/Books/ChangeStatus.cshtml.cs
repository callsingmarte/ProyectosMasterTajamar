using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSwap.Data;
using BookSwap.Models;
using Microsoft.EntityFrameworkCore;
namespace BookSwap.Pages.Books
{
    public class ChangeStatusModel : PageModel
    {
        private readonly BookSwapContext _context;

        public ChangeStatusModel(BookSwapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = await _context.Book.SingleOrDefaultAsync(b => b.Id == Book.Id);

            if (book == null) { 
                return NotFound();
            }

            book.IsAvailable = Book.IsAvailable;

            if (book.IsAvailable) {
                book.LoanDate = null;
                book.ReturnDate = null;
            }
            else
            {
                book.LoanDate = DateTime.Now;
                book.ReturnDate = DateTime.Now.AddDays(7);
            }

            _context.Attach(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
