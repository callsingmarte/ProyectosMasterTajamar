using Ej_EmployeesOneTableApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Ej_EmployeesOneTableApp.Data
{
    public class EmployeesContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments {  get; set; } 
    }
}
