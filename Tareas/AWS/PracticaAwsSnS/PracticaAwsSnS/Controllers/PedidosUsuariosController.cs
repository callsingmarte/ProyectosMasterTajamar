using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaAwsSnS.Data;
using PracticaAwsSnS.Models;
using PracticaAwsSnS.Services;

namespace PracticaAwsSnS.Controllers
{
    [Authorize]
    public class PedidosUsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SnsService _snsService;

        public PedidosUsuariosController(AppDbContext context, SnsService snsService)
        {
            _context = context;
            _snsService = snsService;
        }

        public async Task<IActionResult> Index()
        {
            List<Pedido> pedidos = await _context.Pedidos.ToListAsync();

            return View(pedidos);
        }

        public async Task<IActionResult> Compra(int pedidoId)
        {

            Pedido pedido = await _context.Pedidos.SingleOrDefaultAsync(p => p.Id == pedidoId);

            if (pedido == null) 
            {
                return NotFound();
            }

            PedidoUsuario pedidoUsuario = new PedidoUsuario
            {
                IdPedido = pedido.Id,
                Pedido = pedido,
            };

            return View(pedidoUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Compra(PedidoUsuario pedidoUsuario)
        {
            Usuario usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == Convert.ToInt32(User.FindFirst("UsuarioId").Value));

            if(usuario == null)
            {
                return RedirectToAction("Logout", "Usuarios");
            }

            Pedido pedido = await _context.Pedidos.SingleOrDefaultAsync(p => p.Id == pedidoUsuario.IdPedido);

            if (pedido == null) 
            {
                return RedirectToAction("Index");
            }

            PedidoUsuario pedidoComprado = new PedidoUsuario
            {
                IdUsuario = usuario.Id,
                IdPedido = pedido.Id,
                Cantidad = pedidoUsuario.Cantidad > 0 ? pedidoUsuario.Cantidad : 1,
                PrecioTotal = pedidoUsuario.PrecioTotal >= 0 ? pedidoUsuario.PrecioTotal : pedido.Precio
            };

            _context.Add(pedidoComprado);
            _context.SaveChanges();

            //Enviar notificacion SNS
            bool notificationStatus = await _snsService.SendNotification($"Pedido creado con exito para {usuario.Email}" +
                $" aqui los detalles del pedido: " +
                $" Nombre Producto: { pedido.Nombre } " +
                $" Cantidad: {pedidoComprado.Cantidad} " +
                $" Precio Total: {pedidoComprado.PrecioTotal.ToString(System.Globalization.CultureInfo.InvariantCulture)} ");

            if (!notificationStatus)
            {
                return View("NotificacionError");
            }

            return View("PedidoCompletado", pedidoComprado);
        }
    }
}
