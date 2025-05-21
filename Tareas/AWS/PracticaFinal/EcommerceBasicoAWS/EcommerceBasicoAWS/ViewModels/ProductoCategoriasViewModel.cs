using EcommerceBasicoAWS.Models;

namespace EcommerceBasicoAWS.ViewModels
{
    public class ProductoCategoriasViewModel
    {
        public Producto? Producto { get; set; }
        public List<Categoria>? Categorias { get; set; }
        public string? MainImageUrl { get; set; }
    }
}
