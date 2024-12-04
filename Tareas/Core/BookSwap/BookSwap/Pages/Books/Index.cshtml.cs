using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookSwap.Data;
using BookSwap.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookSwap.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookSwap.Data.BookSwapContext _context;

        public IndexModel(BookSwap.Data.BookSwapContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = _context.Book.Select(b => b.Genre);

            var books = _context.Book.Select(b => b);

            if (!string.IsNullOrEmpty(BookGenre))
            {
                books = books.Where(b => b.Genre == BookGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Book = await books.ToListAsync();
        }
    }
}
