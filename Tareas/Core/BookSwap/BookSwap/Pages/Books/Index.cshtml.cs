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
using X.PagedList;
using X.PagedList.Extensions;

namespace BookSwap.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookSwap.Data.BookSwapContext _context;

        public IndexModel(BookSwap.Data.BookSwapContext context)
        {
            _context = context;
        }

        public IPagedList<Book>? Book { get;set; }
        public SelectList? Genres { get; set; }

        public int PageNumber { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }

        public async Task OnGetAsync(int? pageNumber = 1)
        {
            IQueryable<string> genreQuery = _context.Book.Select(b => b.Genre);

            ChangeBookStatusOnReturnDate();

            var books = _context.Book.Select(b => b);

            if (!string.IsNullOrEmpty(BookGenre))
            {
                books = books.Where(b => b.Genre == BookGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Book = books.ToPagedList(Convert.ToInt32(pageNumber), 5);
        }

        public void ChangeBookStatusOnReturnDate()
        {
            var books = _context.Book.Where(b => b.ReturnDate <= DateTime.Now).ToList();

            foreach (var book in books) {
                book.IsAvailable = true;
                book.ReturnDate = null;
                book.LoanDate = null;
                _context.Book.Update(book);
                _context.SaveChangesAsync();
            }            
        }
    }
}
