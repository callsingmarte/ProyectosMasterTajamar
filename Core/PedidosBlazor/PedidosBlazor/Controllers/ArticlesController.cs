using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosBlazor.Models;
using PedidosBlazor.Services;

namespace PedidosBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        //Obtener todos los articulos
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            try
            {
                var articles = await _articleService.GetArticlesAsync();
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Obtener uno
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            try
            {
                var article = await _articleService.GetArticleByIdAsync(id);
                if(article == null)
                {
                    return NotFound();
                }
                return Ok(article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error: {ex.Message}");
            }
        }

        // Crear un nuevo artículo
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            try
            {
                if (article == null)
                {
                    return BadRequest("Article is null");
                }

                await _articleService.AddArticleAsync(article);
                return CreatedAtAction(nameof(GetArticle), new { id = article.ID }, article); // 201 Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Actualizar un artículo
        [HttpPut("{id}")]
        public async Task<ActionResult> PutArticle(int id, Article article)
        {
            try
            {
                if (id != article.ID)
                {
                    return BadRequest("Article ID mismatch");
                }

                var existingArticle = await _articleService.GetArticleByIdAsync(id);
                if (existingArticle == null)
                {
                    return NotFound();
                }

                await _articleService.UpdateArticleAsync(article);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Eliminar un artículo
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            try
            {
                var article = await _articleService.GetArticleByIdAsync(id);
                if (article == null)
                {
                    return NotFound();
                }

                await _articleService.DeleteArticleAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
