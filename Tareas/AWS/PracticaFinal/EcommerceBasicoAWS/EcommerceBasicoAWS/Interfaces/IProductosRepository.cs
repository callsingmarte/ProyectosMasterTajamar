using EcommerceBasicoAWS.Enums;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.ViewModels;

namespace EcommerceBasicoAWS.Interfaces
{
    public interface IProductosRepository
    {
        public Task<ProductosViewModel> GetProductos(
            SearchTypes searchType = SearchTypes.List,
            ProductosFilters? filters = null,
            int page = 1,
            int resultsPerPage = 5);
        public Task<Producto?> GetProducto(Guid id);
        public Task<bool> AddProducto(Producto producto);
        public bool UpdateProducto(Producto producto);
        public Task<bool> DeleteProducto(Guid id);
    }
}
