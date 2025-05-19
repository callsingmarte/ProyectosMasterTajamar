using EcommerceBasicoAWS.Data;
using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace EcommerceBasicoAWS.Repositories
{
    public class CategoriasRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignOrRemoveCategoriaProducto(Guid IdProducto, Guid IdCategoria, bool assign)
        {
            Categoria? categoria = await _context.Categorias.SingleOrDefaultAsync(c => c.IdCategoria == IdCategoria);
            if (categoria == null) 
            {
                return false;
            } 
            Producto? producto = await _context.Productos.SingleOrDefaultAsync(p => p.IdProducto == IdProducto);

            if(producto == null)
            {
                return false;
            }

            ProductoCategoria productoCategoria = new ProductoCategoria
            {
                IdProducto = IdProducto,
                IdCategoria = IdCategoria,
            };

            bool status = false;

            try
            {
                if (assign) {
                    _context.ProductosCategorias.Add(productoCategoria);
                }
                else
                {
                    _context.ProductosCategorias.Remove(productoCategoria);
                }

                _context.SaveChanges();

                status = true;
            }
            catch (Exception ex) {
                status = false;
            }

            return status;
        }

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public async Task<bool> DeleteCategoria(Guid IdCategoria)
        {
            bool deletionSuccess = false;
            Categoria categoria = await GetCategoria(IdCategoria);

            if (categoria == null) {
                _context.Categorias.Remove(categoria);
                deletionSuccess = true;
            }
 
            _context.SaveChanges();

            return deletionSuccess;
        }

        public async Task<Categoria?> GetCategoria(Guid IdCategoria)
        {
            Categoria? categoria = await _context.Categorias.SingleOrDefaultAsync(c => c.IdCategoria == IdCategoria);

            return categoria;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            List<Categoria> categorias = await _context.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<List<Categoria>> GetCategoriasByProducto(Guid idProducto)
        {
            List<Categoria> categorias = await _context.ProductosCategorias
                .Where(pc => pc.IdProducto == idProducto).Select( c => new Categoria
                {
                    IdCategoria = c.Categoria.IdCategoria,
                    Nombre = c.Categoria.Nombre                    
                }).ToListAsync();

            return categorias;
        }

        public async Task<bool> UpdateCategoria(Guid IdCategoria, Categoria categoria)
        {
            if (IdCategoria != categoria.IdCategoria) { 
                return false;
            }
            bool updateStatus = false;

            Categoria categoriaActualizar = await GetCategoria(IdCategoria);

            if (categoriaActualizar != null) {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                updateStatus = true;
            }

            return updateStatus;
        }
    }
}
