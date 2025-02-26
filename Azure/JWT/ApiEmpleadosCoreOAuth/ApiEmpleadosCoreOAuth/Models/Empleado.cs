using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEmpleadosCoreOAuth.Models
{
    [Table("EMPLEADO")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("EMP_NO")]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public string? Apellido { get; set; }
        [Column("OFICIO")]
        public string? Oficio { get; set; }
        [Column("SALARIO")]
        public int? Salario { get; set; }
        [Column("DIR")]
        public int? Director { get; set; }

    }
}
