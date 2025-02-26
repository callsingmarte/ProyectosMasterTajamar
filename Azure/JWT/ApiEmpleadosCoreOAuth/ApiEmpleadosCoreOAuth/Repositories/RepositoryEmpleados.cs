using ApiEmpleadosCoreOAuth.Data;
using ApiEmpleadosCoreOAuth.Models;

namespace ApiEmpleadosCoreOAuth.Repositories
{
    public class RepositoryEmpleados
    {
        EmpleadosContext _context;
        public RepositoryEmpleados(EmpleadosContext context)
        {
            _context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            return _context.Empleados.ToList();
        }

        public Empleado BuscarEmpleado(int idempleado)
        {
            return _context.Empleados.SingleOrDefault(x => x.IdEmpleado == idempleado)!;
        }

        public Empleado ExisteEmpleado(string apellido, int empno)
        {
            return _context.Empleados.SingleOrDefault(x => x.Apellido == apellido && x.IdEmpleado == empno)!;
        }
        
        public List<Empleado> GetEmpleadosSubordinados(int idempleado)
        {
            var consulta = from datos in _context.Empleados 
                           where datos.Director == idempleado
                           select datos;

            return consulta.ToList();
        }
    }
}
