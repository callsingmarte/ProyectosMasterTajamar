using EjerciciosCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjerciciosCore.ViewModels
{
    public class EmpleadoDepartamentosViewModel
    {
        public Empleado? Empleado { get; set; }
        public Departamento? Departamento { get; set; }
        public SelectList? DepartamentoList { get; set; }
    }
}
