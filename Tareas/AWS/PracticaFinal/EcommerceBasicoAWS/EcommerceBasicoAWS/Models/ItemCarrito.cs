﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBasicoAWS.Models
{
    public class ItemCarrito
    {
        [Key]
        public Guid IdItemCarrito { get; set; }
        [ForeignKey(nameof(Carrito))]
        public Guid IdCarrito { get; set; }
        public virtual Carrito? Carrito { get; set; }
        [ForeignKey(nameof(Producto))]
        public Guid IdProducto { get; set; }
        public virtual Producto? Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
