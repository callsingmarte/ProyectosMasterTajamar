using EcommerceBasicoAWS.Models;

namespace EcommerceBasicoAWS.Interfaces
{
    public interface ICategoriaService
    {
        public Task<List<Categoria>> GetCategorias();
        public Task<List<Categoria>> GetProductoCategorias(Guid IdProducto);
        public Task<Categoria> AddCategoria(Categoria categoria);
        public Task<bool> UpdateCategoria(Guid IdCategoria, Categoria categoria);
        public Task<bool> RemoveCategoria(Guid IdCategoria);
        public void AddCategoriasProducto(Guid IdProducto, List<Categoria> categorias);
        public Task<bool> AssignCategoriaProducto(Guid IdProducto, Categoria categoria);
        public Task<bool> RemoveCategoriaProducto(Guid IdProducto, Categoria categoria);
    }
}
