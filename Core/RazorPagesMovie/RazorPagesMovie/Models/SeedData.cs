using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context == null || context.Movie == null) 
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }
                //Buscamos movies
                /*
                if (context.Movie.Any()) 
                {
                    return;
                }
                */
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "M"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "S"
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = new DateTime(1972, 3, 24),
                        Genre = "Crime",
                        Price = 14.99M,
                        Rating = "M"
                    },
                    new Movie
                    {
                        Title = "Inception",
                        ReleaseDate = new DateTime(2010, 7, 16),
                        Genre = "Science Fiction",
                        Price = 19.99M,
                        Rating = "S"
                    },
                    new Movie
                    {
                        Title = "The Dark Knight",
                        ReleaseDate = new DateTime(2008, 7, 18),
                        Genre = "Action",
                        Price = 12.99M,
                        Rating = "M",
                    }
                );

                /*
                foreach (var movie in context.Movie)
                {
                    var existingMovie = context.Movie.FirstOrDefault(m => m.Title == movie.Title);
                    if (existingMovie != null)
                    {
                        context.Movie.Add(movie);
                    }
                    else
                    {
                        existingMovie.Rating = movie.Rating;
                        context.Movie.Update(existingMovie);
                    }
                }
                */
                context.SaveChanges();
            }
        }
    }
}
