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
        private readonly IAwsS3Service _awsS3Service;
        private readonly ApplicationDbContext? _context;
        private readonly ILogger<ProductosRepository> _logger;
        private readonly string _bucketName; 

        public ProductosRepository(ApplicationDbContext context, ILogger<ProductosRepository> logger, IAwsS3Service awsS3Service, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _awsS3Service = awsS3Service;
            _bucketName = configuration["bucketName"];
        }

        public async Task<bool> AddMultimediasProducto(Guid idProducto, List<IFormFile> files)
        {
            bool respuesta = false;
            try
            {
                foreach (IFormFile file in files)
                {
                    string uploadResult = await _awsS3Service.UploadFileAsync(file, _bucketName, "");

                    if (!uploadResult.Contains("successfully")) {
                        throw new Exception("Error no se ha podido subir el archivo");
                    }

                    string tipo = GetFileType(file.Name);
                    int orden = 1;

                    MultimediaProducto prevoMultimediaProducto = await _context.MultimediaProductos.OrderByDescending(o => o.Orden).FirstOrDefaultAsync(
                        m => m.IdProducto == idProducto && m.Tipo == tipo
                    );

                    if(prevoMultimediaProducto != null)
                    {
                        orden = prevoMultimediaProducto.Orden + 1;
                    }

                    MultimediaProducto multimediaProducto = new MultimediaProducto()
                    {
                        IdProducto = idProducto,
                        NombreArchivo = file.Name,
                        Descripcion = "",
                        Url = "",
                        Tipo = tipo, 
                        Orden = orden,
                        FechaCreacion = DateTime.Now,
                    };

                    await _context.MultimediaProductos.AddAsync(multimediaProducto);
                }

                await _context.SaveChangesAsync();
                respuesta = true;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
            }

            return respuesta;
        }

        public string GetFileType(string filename)
        {
            string type = "";

            return type;
        }

        public async Task<Producto?> AddProducto(Producto producto)
        {
            try
            {
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();

                return producto;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return null;
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

        public async Task<MultimediaProducto> GetProductoMainImage(Guid idProducto)
        {
            MultimediaProducto? mainImage = await _context.MultimediaProductos
                .SingleOrDefaultAsync(m =>
                    m.IdProducto == idProducto
                    && m.Tipo == ITiposMultimedia.IMAGEN
                    && m.Orden == 1
                );

            return mainImage;
        }

        public async Task<List<MultimediaProducto>> GetProductoMultimedia(Guid idProducto)
        {
            List<MultimediaProducto> multimediaProducto = await _context.MultimediaProductos
                    .Where(m => m.IdProducto == idProducto)
                    .ToListAsync();

            return multimediaProducto;
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

            List<MultimediaProducto> productosMainImages = new List<MultimediaProducto>();
            foreach(Producto producto in productos)
            {
                MultimediaProducto mainImage = await GetProductoMainImage(producto.IdProducto);
                if (mainImage != null) {
                    productosMainImages.Add(mainImage);
                }
            }

            return new ProductosViewModel {
                SearchTypes = searchType,
                Productos = productos,
                ProductosMainImages = productosMainImages,
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
