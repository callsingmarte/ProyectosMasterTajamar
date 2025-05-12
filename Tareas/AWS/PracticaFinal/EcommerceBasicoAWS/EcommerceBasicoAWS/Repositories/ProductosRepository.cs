using EcommerceBasicoAWS.Data;
using EcommerceBasicoAWS.Enums;
using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using EcommerceBasicoAWS.ViewModels;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace EcommerceBasicoAWS.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ProductosRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddProducto(Producto producto)
        {
            try
            {
                await _context.Productos.AddAsync(producto);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteProducto(Guid id)
        {
            Producto? producto = await GetProducto(id);

            bool response = false;

            if (producto != null && producto.IdProducto == id)
            {
                try
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges(true);
                    response = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    response = false;
                }
            }

            return response;
        }

        public async Task<Producto?> GetProducto(Guid id)
        {
            Producto? producto = await _context.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

            return producto;
        }

        public async Task<ProductosViewModel> GetProductos(
            SearchTypes searchType = SearchTypes.List,
            ProductosFilters? filters = null,
            int page = 1,
            int resultsPerPage = 5)
        {
            IQueryable<Producto> query = _context.Productos;
            IQueryable<Producto> queryTotalResults = _context.Productos;
            int totalResults = 0;

            if (searchType == SearchTypes.List)
            {
                query = query
                    .Skip((page - 1) * resultsPerPage)
                    .Take(resultsPerPage);

                totalResults = await queryTotalResults.CountAsync();
            }
            else if (filters != null)
            {
                if (!string.IsNullOrEmpty(filters.Nombre))
                {
                    query = query.Where(p => p.Nombre.Contains(filters.Nombre));
                    queryTotalResults = queryTotalResults.Where(p => p.Nombre.Contains(filters.Nombre));
                }

                if (!string.IsNullOrEmpty(filters.Descripcion))
                {
                    query = query.Where(p => p.Descripcion.Contains(filters.Descripcion));
                    queryTotalResults = queryTotalResults.Where(p => p.Descripcion.Contains(filters.Descripcion));
                }

                if (filters.Precio.HasValue && filters.Precio >= 0)
                {
                    query = query.Where(p => p.Precio >= filters.Precio);
                    queryTotalResults = queryTotalResults.Where(p => p.Precio >= filters.Precio);
                }

                if (filters.Stock.HasValue && filters.Stock >= 0)
                {
                    query = query.Where(p => p.Stock >= filters.Stock);
                    queryTotalResults = queryTotalResults.Where(p => p.Stock >= filters.Stock);
                }

                if (filters.FechaCreacion.HasValue)
                {
                    query = query.Where(p => p.FechaCreacion >= filters.FechaCreacion && p.FechaCreacion < DateTime.Now);
                    queryTotalResults = queryTotalResults.Where(p => p.FechaCreacion >= filters.FechaCreacion && p.FechaCreacion < DateTime.Now);
                }

                if (filters.FechaActualizacion.HasValue)
                {
                    query = query.Where(p => p.FechaActualizacion >= filters.FechaActualizacion && p.FechaActualizacion < DateTime.Now);
                    queryTotalResults = queryTotalResults.Where(p => p.FechaActualizacion >= filters.FechaActualizacion && p.FechaActualizacion < DateTime.Now);
                }

                query = query
                    .Skip((page - 1) * resultsPerPage)
                    .Take(resultsPerPage);

                totalResults = await queryTotalResults.CountAsync();
            }

            List<Producto> productos = await query.ToListAsync();


            return new ProductosViewModel {
                SearchTypes = searchType,
                Productos = productos,
                Filters = filters,
                CurrentPage = page,
                ResultsPerPage = resultsPerPage,
                TotalResults = totalResults
            };
        }

        public bool UpdateProducto(Producto producto)
        {
            bool response = false;
            try
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                response = true;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);                
            }

            return response;
        }
    }
}
