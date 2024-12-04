using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookSwap.Models;

namespace BookSwap.Data
{
    public class BookSwapContext : DbContext
    {
        public BookSwapContext (DbContextOptions<BookSwapContext> options)
            : base(options)
        {
        }

        public DbSet<BookSwap.Models.Book> Book { get; set; } = default!;
    }
}
