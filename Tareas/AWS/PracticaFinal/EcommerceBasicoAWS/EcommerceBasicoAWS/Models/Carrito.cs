using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBasicoAWS.Models
{
    public class Carrito
    {
        [Key]
        public Guid IdCarrito { get; set; }
        [ForeignKey(nameof(Usuario))]
        public string? IdUsuario { get; set; }
        public virtual IdentityUser? Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual ICollection<ItemCarrito>? ItemsCarrito { get; set; }
        public decimal Total { get; set; }
    }
}
