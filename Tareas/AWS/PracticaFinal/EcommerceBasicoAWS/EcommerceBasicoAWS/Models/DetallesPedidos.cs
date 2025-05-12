using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBasicoAWS.Models
{
    public class DetallesPedidos
    {
        [Key]
        public Guid IdDetalle { get; set; }
        [ForeignKey(nameof(Pedido))]
        public Guid IdPedido { get; set; }
        public virtual Pedido? Pedido { get; set; }
        [ForeignKey(nameof(Producto))]
        public Guid IdProducto { get; set; }
        public virtual Producto? Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
