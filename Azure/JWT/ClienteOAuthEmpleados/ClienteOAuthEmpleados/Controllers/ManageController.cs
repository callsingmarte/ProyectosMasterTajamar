using ClienteOAuthEmpleados.Models;
using ClienteOAuthEmpleados.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClienteOAuthEmpleados.Controllers
{
    public class ManageController : Controller
    {
        RepositoryEmpleados repo;

        public ManageController(RepositoryEmpleados repository)
        {
            repo = repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string token = await repo.GetToken(username, password);

            if (token == null) 
            {
                ViewData["MENSAJE"] = "Usuario o Password Incorrectos";
                return View();
            }
            else {
                Empleado empleado = await repo.PerfilEmpleado(token);
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, empleado.IdEmpleado.ToString()));

                //Almacenamos el numero de empleado
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, empleado.IdEmpleado.ToString()));
                //Almacenamos el apellido
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, empleado.Apellido!));
                //Almacenamos el oficio
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, empleado.Oficio!));

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    principal, 
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddMinutes(60),
                    });
                //Almacenamos el token una vez que el usuario ya existe
                HttpContext.Session.SetString("TOKEN", token);

                return RedirectToAction("Index", "Empleados");
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("TOKEN");

            return RedirectToAction("Index", "Home");
        }
    }
}
