using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticaAwsSnS.Data;
using PracticaAwsSnS.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using PracticaAwsSnS.Services;

namespace PracticaAwsSnS.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext? _context;
        private readonly SnsService _snsService;

        public UsuariosController(AppDbContext context, SnsService snsService)
        {
            _context = context;
            _snsService = snsService;
        }


        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarUsuario([Bind("Id, Nombre, Email, Contrasena")]Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                //Hashear contraseña
                var passwordHasher = new PasswordHasher<Usuario>();
                usuario.Contrasena = passwordHasher.HashPassword(usuario, usuario.Contrasena);

                _context.Add(usuario);

                await _context.SaveChangesAsync();
                //Enviar notificacion SNS de que se ha registrado correctamente
                bool notificationStatus = await _snsService.SendNotification($"Bienvenido a la tienda { usuario.Nombre }" +
                    $" su cuenta con correo {usuario.Email} se ha registrado correctamente");

                if (!notificationStatus)
                {
                    return View("NotificacionError");
                }

                return View("RegistroCompletado", usuario);
            }

            return View(usuario);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Contrasena")] Usuario usuario)
        {
            if (!ModelState.IsValid) 
            {
                return View(usuario);
            }

            Usuario usuarioRegistrado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (usuarioRegistrado != null)
            {
                var passwordHasher = new PasswordHasher<Usuario>();
                var resultado = passwordHasher.VerifyHashedPassword(usuarioRegistrado, usuarioRegistrado.Contrasena, usuario.Contrasena);

                if (resultado == PasswordVerificationResult.Success) {
                    //Agregar usuario registrado a las cookies o a la sesion
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuarioRegistrado.Email),
                        new Claim("UsuarioId", usuarioRegistrado.Id.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, // Esto hace que la cookie persista más allá de la sesión del navegador
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    return RedirectToAction("Index", "PedidosUsuarios");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
                    return View(usuario);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
                return View(usuario);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
