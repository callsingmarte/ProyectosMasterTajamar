using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using SQLitePCL;

namespace EcommerceBasicoAWS.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            Categoria categoriaCreada = await _categoriaRepository.CreateCategoria(categoria);

            return categoriaCreada;
        }

        public void AddCategoriasProducto(Guid IdProducto, List<Categoria> categorias)
        {
            foreach (Categoria categoria in categorias) {
                _categoriaRepository.AssignOrRemoveCategoriaProducto(IdProducto, categoria.IdCategoria, true);
            }
        }

        public Task<bool> AssignCategoriaProducto(Guid IdProducto, Categoria categoria)
        {
           Task<bool> response = _categoriaRepository.AssignOrRemoveCategoriaProducto(IdProducto, categoria.IdCategoria, true);

            return response;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
           return await _categoriaRepository.GetCategorias();
        }

        public async Task<List<Categoria>> GetProductoCategorias(Guid IdProducto)
        {
            return await _categoriaRepository.GetCategoriasByProducto(IdProducto);
        }

        public Task<bool> RemoveCategoria(Guid IdCategoria)
        {
            Task<bool> response = _categoriaRepository.DeleteCategoria(IdCategoria);

            return response;
        }

        public Task<bool> RemoveCategoriaProducto(Guid IdProducto, Categoria categoria)
        {
            Task<bool> response = _categoriaRepository.AssignOrRemoveCategoriaProducto(IdProducto, categoria.IdCategoria, false);

            return response;
        }

        public Task<bool> UpdateCategoria(Guid IdCategoria, Categoria categoria)
        {
            Task<bool> response = _categoriaRepository.UpdateCategoria(IdCategoria, categoria);

            return response;
        }
    }
}
