using EcommerceBasicoAWS.Models;

namespace EcommerceBasicoAWS.Interfaces
{
    public interface IProductoService
    {
        public List<Producto> GetProductos();
        public Producto GetProducto(int id);
        public bool AddProducto(Producto producto);
        public bool UpdateProducto(Producto producto);
        public bool DeleteProducto(int id);
    }
}
