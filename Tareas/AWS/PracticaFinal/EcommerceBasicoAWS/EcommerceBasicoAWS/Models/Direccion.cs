using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBasicoAWS.Models
{
    public class Direccion
    {
        [Key]
        public Guid IdDireccion { get; set; }
        [ForeignKey(nameof(Usuario))]
        public string? IdUsuario { get; set; }
        public virtual IdentityUser? Usuario { get; set; }
        public string? Domicilio { get; set; }
        public int CodigoPostal { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public bool principal { get; set; }
    }
}
