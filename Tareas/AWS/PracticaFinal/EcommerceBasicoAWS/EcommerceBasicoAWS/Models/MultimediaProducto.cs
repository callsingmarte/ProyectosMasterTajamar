using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBasicoAWS.Models
{
    public class MultimediaProducto
    {
        [Key]
        public int IdMultimedia { get; set; }
        [ForeignKey(nameof(Producto))]
        public Guid IdProducto { get; set; }
        public virtual Producto? Producto { get; set; }
        public string? Tipo { get; set; } // Podrías usar un enum aquí también ('imagen', 'video', 'pdf', 'otro')
        public string? Url { get; set; }
        public string? NombreArchivo { get; set; }
        public string? Descripcion { get; set; }
        public int? Orden { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
