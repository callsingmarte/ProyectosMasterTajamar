using System.Text.Json.Serialization;

namespace LibreriaAPI.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        [JsonIgnore]
        public ICollection<Libro>? Libros { get; set; }
    }
}
