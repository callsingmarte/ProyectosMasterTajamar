using EjerciciosCore.Models;
using EjerciciosCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjerciciosCore.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Empleado> empleados = new List<Empleado>();

        static List<Departamento> allDepartamentos = new List<Departamento>
        {
            new Departamento(){ID = 1, Nombre="Accounting"},
            new Departamento(){ID = 2, Nombre="Information Technology"},
            new Departamento(){ID = 3, Nombre="Marketing"},
        };

        public IActionResult Index()
        {
            return View();
        }

        public string PayRate(string name, int rate, int hours)
        {
            return $"{name}, your total pay amount ${rate * hours}";
        }

        public IActionResult AllEmployee()
        {
            if (empleados.Count > 0)
            {
                ViewBag.mediaEmpleados = empleados.Average(e => e.PrecioHora);
            }
            return View(empleados);
        }

        public IActionResult Add()
        {
            var DepartamentoDisplay = allDepartamentos.Select(x => new { Id = x.ID, Value = x.Nombre });
            EmpleadoDepartamentosViewModel vm = new EmpleadoDepartamentosViewModel();
            vm.DepartamentoList = new SelectList(DepartamentoDisplay, "Id", "Value");

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(EmpleadoDepartamentosViewModel vm)
        {
            var departamento = allDepartamentos.SingleOrDefault(x => x.ID == vm.Departamento.ID);
            vm.Empleado.Departamento = departamento;

            empleados.Add(vm.Empleado);
            return RedirectToAction("AllEmployee");
        }

        public IActionResult DeleteEmployee(string valoresABorrar)
        {
            string[] datosABorrar = valoresABorrar.Split(',');

            for (var i = 0; i < datosABorrar.Length; i++)
            {
                int dato = int.Parse(datosABorrar[i]);
                var employee = empleados.SingleOrDefault(em => em.ID == dato);
                empleados.Remove(employee);
            }

            return RedirectToAction("AllEmployee");
        }

        /*
        [HttpDelete]
        public IActionResult DeleteListEmpleados(List<int> ids)
        {
            ids.ForEach(id =>
            {
                Empleado empleadoEliminar = empleados.Single(e => e.ID == Convert.ToInt32(id));
                empleados.Remove(empleadoEliminar);
            });

            return RedirectToAction("AllEmployee");
        }
        */
    }
}
