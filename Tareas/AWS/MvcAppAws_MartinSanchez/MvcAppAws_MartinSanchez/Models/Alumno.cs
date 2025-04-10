using System.ComponentModel.DataAnnotations;

namespace MvcAppAws_MartinSanchez.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Matricula { get; set; } //Ej.- 076-MAT
        public string? Carrera { get; set; } //Nombre de la Carrera : Matemáticas
        public string? EmpresaAsignada { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Estado { get; set; } // Ej: (Activo, Finalizado, En espera) Si quieres puedes      hacer un enum de esto
    }
}
