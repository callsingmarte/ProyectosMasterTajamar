using EcommerceBasicoAWS.Enums;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.ViewModels;

namespace EcommerceBasicoAWS.Interfaces
{
    public interface IProductoService
    {
        public Task<ProductosViewModel> GetProductos(
            SearchTypes searchType = SearchTypes.List,
            ProductosFilters? filters = null,
            int page = 1,
            int resultsPerPage = 5);
        public Task<Producto?> GetProducto(Guid idProducto);
        public Task<Producto> AddProducto(Producto producto, List<IFormFile> files, List<string> categoriasIds);
        public Task<bool> UpdateProducto(Guid idProducto, Producto producto, List<IFormFile> files, List<string> categoriasIds);
        public Task<bool> DeleteProducto(Guid idProducto);
    }
}
