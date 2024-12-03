using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventosAPI_MartinSanchez.Models
{
    [Table("Invitados")]
    public class Invitado
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public bool Confirmado { get; set; }
        public int EventoId { get; set; }
        [JsonIgnore]
        public Evento? Evento { get; set; }
    }
}
