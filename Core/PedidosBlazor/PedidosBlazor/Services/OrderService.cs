using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Data;
using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int id)
        {
            return await _context.Orders.Where(o => o.ArticleID == id).ToListAsync();
        }
        
        public async Task<int> GetTotalOrdersCountAsync(int? id)
        {
            return await _context.Orders.Where(o => o.ArticleID == id).CountAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int id, int page, int quantityPerPage)
        {
            var query = _context.Orders.Where(o => o.ArticleID == id).AsQueryable();

            return await query.Skip((page - 1) * quantityPerPage).Take(quantityPerPage).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderID == id);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
