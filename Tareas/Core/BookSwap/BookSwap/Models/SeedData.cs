using BookSwap.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSwap.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookSwapContext(
                serviceProvider.GetRequiredService <DbContextOptions<BookSwapContext>>()))
            {
                if (context == null || context.Book == null) {
                    throw new ArgumentNullException("Null BookSwapContext");
                }

                if (context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                     new Book
                     {
                         Title = "To Kill a Mockingbird",
                         Author = "Harper Lee",
                         Genre = "Fiction",
                         IsAvailable = true
                     },
                    new Book
                    {
                        Title = "1984",
                        Author = "George Orwell",
                        Genre = "Dystopian",
                        IsAvailable = false,
                        LoanDate = DateTime.Now.AddDays(-5),
                        ReturnDate = DateTime.Now.AddDays(2)
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        Author = "Jane Austen",
                        Genre = "Romance",
                        IsAvailable = true
                    },
                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        Author = "J.D. Salinger",
                        Genre = "Literary Fiction",
                        IsAvailable = false,
                        LoanDate = DateTime.Now.AddDays(-10),
                        ReturnDate = DateTime.Now.AddDays(-3)
                    },
                    new Book
                    {
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        Genre = "Fiction",
                        IsAvailable = true
                    },
                    new Book
                    {
                        Title = "Moby Dick",
                        Author = "Herman Melville",
                        Genre = "Adventure",
                        IsAvailable = false,
                        LoanDate = DateTime.Now.AddDays(-3),
                        ReturnDate = DateTime.Now.AddDays(4)
                    },
                    new Book
                    {
                        Title = "War and Peace",
                        Author = "Leo Tolstoy",
                        Genre = "Historical Fiction",
                        IsAvailable = true
                    },
                    new Book
                    {
                        Title = "The Hobbit",
                        Author = "J.R.R. Tolkien",
                        Genre = "Fantasy",
                        IsAvailable = false,
                        LoanDate = DateTime.Now.AddDays(-15),
                        ReturnDate = DateTime.Now.AddDays(-8)
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        Author = "J.R.R. Tolkien",
                        Genre = "Fantasy",
                        IsAvailable = true
                    },
                    new Book
                    {
                        Title = "Crime and Punishment",
                        Author = "Fyodor Dostoevsky",
                        Genre = "Psychological Fiction",
                        IsAvailable = false,
                        LoanDate = DateTime.Now.AddDays(-20),
                        ReturnDate = DateTime.Now.AddDays(-13)
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
