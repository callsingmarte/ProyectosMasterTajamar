namespace EjerciciosCore.Models
{
    public class Empleado
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public double PrecioHora { get; set; }
        public Departamento? Departamento { get; set; }
    }
}
