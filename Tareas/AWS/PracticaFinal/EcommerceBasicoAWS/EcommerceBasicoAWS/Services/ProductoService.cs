using EcommerceBasicoAWS.Enums;
using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.Repositories;
using EcommerceBasicoAWS.ViewModels;

namespace EcommerceBasicoAWS.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductosRepository _productoRepository;

        public ProductoService(IProductosRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<bool> AddProducto(Producto producto, List<IFormFile> files)
        {
            Producto? productoCreado = await _productoRepository.AddProducto(producto);

            bool areFilesUpload = false;
            if (productoCreado != null) {
                 areFilesUpload = await _productoRepository.AddMultimediasProducto(productoCreado.IdProducto, files);
            }

            return areFilesUpload;
        }

        public async Task<bool> DeleteProducto(Guid id)
        {
            bool response = await _productoRepository.DeleteProducto(id);

            return response;
        }

        public async Task<Producto?> GetProducto(Guid id)
        {
            Producto? producto = await _productoRepository.GetProducto(id);

            return producto;
        }

        public async Task<ProductosViewModel> GetProductos(
            SearchTypes searchType = SearchTypes.List,
            ProductosFilters? filters = null,
            int page = 1,
            int resultsPerPage = 5)
        {
            ProductosViewModel productosVm = await _productoRepository.GetProductos(searchType, filters, page, resultsPerPage);

            return productosVm;
        }

        public async Task<bool> UpdateProducto(Guid id, Producto producto, List<MultimediaProducto> multimediasProducto)
        {

            if (producto.IdProducto != id) {
                return false;
            }

            bool response = false;

            Producto? productoEncontrado = await _productoRepository.GetProducto(id);

            if (productoEncontrado != null && producto.IdProducto == productoEncontrado.IdProducto) {
                response = _productoRepository.UpdateProducto(producto);
            }

            return response;
        }
    }
}
