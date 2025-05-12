﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceBasicoAWS.Models
{
    public class Producto
    {
        [Key]
        public Guid IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
