using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync(int id, int page, int quantityPerPage);
        Task<Order> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order article);
        Task UpdateOrderAsync(Order article);
        Task DeleteOrderAsync(int id);
    }
}
