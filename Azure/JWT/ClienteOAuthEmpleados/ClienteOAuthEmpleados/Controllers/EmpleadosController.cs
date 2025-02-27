using ClienteOAuthEmpleados.Filters;
using ClienteOAuthEmpleados.Models;
using ClienteOAuthEmpleados.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClienteOAuthEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repository)
        {
            repo = repository;
        }

        [EmpleadosAuthorize]
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("TOKEN")!;
            Empleado empleado = await repo.PerfilEmpleado(token);
            return View(empleado);
        }

        [EmpleadosAuthorize]
        public async Task<IActionResult> Subordinados()
        {
            string token = HttpContext.Session.GetString("TOKEN")!;
            List<Empleado> empleados = await repo.GetSubordinados(token);
            return View(empleados);
        }

        public async Task<IActionResult> DetallesEmpleado(int empno)
        {
            Empleado emp = await repo.BuscarEmpleado(empno);
            return View(emp);
        }
    }
}
