using Ej_EmployeesOneTableApp.Data;
using Ej_EmployeesOneTableApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ej_EmployeesOneTableApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeesContext? _db;

        public EmployeeController(EmployeesContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> AllEmployees()
        {
            var employees = await _db!.Employees.ToListAsync();
            return View(employees);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            _db!.Add(employee);
            await _db.SaveChangesAsync();

            return RedirectToAction("AllEmployees");
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            Employee? employee;
            employee = await _db!.Employees.FindAsync(id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            _db!.Update(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllEmployees");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee? employee = await _db!.Employees.FindAsync(id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Employee employee)
        {
            _db!.Remove(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllEmployees");
        }
    }
}
