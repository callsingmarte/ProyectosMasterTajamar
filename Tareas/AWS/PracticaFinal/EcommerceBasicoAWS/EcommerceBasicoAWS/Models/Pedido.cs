using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBasicoAWS.Models
{
    public class Pedido
    {
        [Key]
        public Guid IdPedido { get; set; }
        public int Numero { get; set; }
        [ForeignKey(nameof(Usuario))]
        public string? IdUsuario { get; set; }
        public virtual IdentityUser? Usuario { get; set; }
        [ForeignKey(nameof(Direccion))]
        public Guid IdDireccion { get; set; }
        public virtual Direccion? Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Estado { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<DetallesPedidos>? DetallesPedidos { get; set; }
    }
}
