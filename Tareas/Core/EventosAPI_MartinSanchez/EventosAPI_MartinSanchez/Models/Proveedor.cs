using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventosAPI_MartinSanchez.Models
{
    [Table("Proveedores")]
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Servicio Servicio { get; set; }
        public decimal Coste { get; set; }
        public int EventoId { get; set; }
        [JsonIgnore]
        public Evento? Evento { get; set; }
    }

    public enum Servicio
    {
        Catering = 1,
        Musica,
        Decoracion,
        Otro
    }
}
