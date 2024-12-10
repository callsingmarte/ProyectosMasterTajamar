using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public interface IOrderService
    {
        //el id es el del articulo
        Task<IEnumerable<Order>> GetAllOrdersAsync(int id);
        //el id es el del articulo
        Task<int> GetTotalOrdersCountAsync(int? id);
        //el id es el del articulo
        Task<IEnumerable<Order>> GetAllOrdersAsync(int id, int page, int quantityPerPage);
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
