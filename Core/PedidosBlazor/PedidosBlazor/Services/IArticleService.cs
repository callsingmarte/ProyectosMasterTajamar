using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesAsync();
        Task<List<Article>> GetArticlesAsync(int page, int quantityPerPage);
        Task<Article> GetArticleByIdAsync(int id);
        Task AddArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(int id);
    }
}
