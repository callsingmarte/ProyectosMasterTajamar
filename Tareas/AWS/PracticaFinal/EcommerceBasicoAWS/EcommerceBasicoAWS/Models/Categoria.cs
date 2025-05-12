using System.ComponentModel.DataAnnotations;

namespace EcommerceBasicoAWS.Models
{
    public class Categoria
    {
        [Key]
        public Guid IdCategoria { get; set; }       
        public string? Nombre { get; set; }
    }
}
