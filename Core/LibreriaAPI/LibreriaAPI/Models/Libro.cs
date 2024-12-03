using System.Text.Json.Serialization;

namespace LibreriaAPI.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int AutorId  { get; set; }
        [JsonIgnore]
        public Autor? Autor { get; set; }
        public int AnioPublicacion { get; set; }
    }
}
