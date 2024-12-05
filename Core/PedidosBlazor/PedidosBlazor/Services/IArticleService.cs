using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task AddArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(int id);
    }
}
