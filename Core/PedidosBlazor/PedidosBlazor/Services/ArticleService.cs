using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Data;
using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public class ArticleService : IArticleService
    {
        private readonly AppDbContext _context;

        public ArticleService(AppDbContext context)
        {
            _context = context;
        }

        //Añadir un nuevo articulo
        public async Task AddArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        //Eliminar un articulo

        public async Task DeleteArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null) 
            { 
               _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

        //Obtener un articulo por su ID
        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.Include(a => a.Orders).FirstOrDefaultAsync(a => a.ID == id);
        }
        //Obtener la lista de Articulos
        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _context.Articles.Include(a => a.Orders).ToListAsync();
        }

        //Actualizar un articulo
        public async Task UpdateArticleAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }
    }
}
