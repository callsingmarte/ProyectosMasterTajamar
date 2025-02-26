using ApiEmpleadosCoreOAuth.Models;
using ApiEmpleadosCoreOAuth.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiEmpleadosCoreOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        RepositoryEmpleados _repo;

        public EmpleadosController(RepositoryEmpleados repositorio)
        {
            _repo = repositorio;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Empleado>> GetEmpleados()
        {
            return _repo.GetEmpleados();
        }

        [HttpGet("{id}")]
        public ActionResult<Empleado> BuscarEmpleado(int id)
        {
            return _repo.BuscarEmpleado(id);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Empleado> PerfilEmpleado()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData")!.Value;

            Empleado emp = JsonConvert.DeserializeObject<Empleado>(json)!;
            return emp;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Empleado>> Subordinados()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData")!.Value;
            Empleado emp = JsonConvert.DeserializeObject<Empleado>(json)!;
            List<Empleado> empleados = _repo.GetEmpleadosSubordinados(emp.IdEmpleado);

            return empleados;
        }
    }
}
