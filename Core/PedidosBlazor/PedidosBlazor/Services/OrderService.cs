using PedidosBlazor.Models;

namespace PedidosBlazor.Services
{
    public class OrderService : IOrderService
    {
        public Task AddOrderAsync(Order article)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync(int id, int page, int quantityPerPage)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(Order article)
        {
            throw new NotImplementedException();
        }
    }
}
