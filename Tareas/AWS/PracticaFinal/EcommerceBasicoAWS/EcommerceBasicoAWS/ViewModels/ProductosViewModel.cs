using EcommerceBasicoAWS.Enums;
using EcommerceBasicoAWS.Models;

namespace EcommerceBasicoAWS.ViewModels
{
    public class ProductosViewModel
    {
        public List<Producto>? Productos { get; set; }
        public ProductosFilters? Filters { get; set; }
        public SearchTypes SearchTypes { get; set; }
        public int CurrentPage { get; set; }
        public int ResultsPerPage {  get; set; }
        public int TotalResults { get; set; }
    }
}
