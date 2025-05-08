namespace Publicaciones.Models
{
    public class SearchRequest
    {
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
