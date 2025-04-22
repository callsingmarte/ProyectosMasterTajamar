using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaAwsSnS.Models
{
    public class PedidoUsuario
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
