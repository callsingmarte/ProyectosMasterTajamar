using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IPagedList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString {  get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }


        public async Task OnGetAsync(int pageNumber = 1)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre 
                                            select m.Genre;

            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title!.Contains(SearchString));
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            int pageSize = 5;

            Movie = movies.ToPagedList(pageNumber, pageSize);
        }
    }
}
