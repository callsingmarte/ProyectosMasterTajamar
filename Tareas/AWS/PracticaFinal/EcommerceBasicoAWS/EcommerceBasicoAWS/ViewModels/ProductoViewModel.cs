using EcommerceBasicoAWS.Enums;
using EcommerceBasicoAWS.Models;

namespace EcommerceBasicoAWS.ViewModels
{
    public class ProductoViewModel
    {
        public Producto? Producto { get; set; }
        public List<MultimediaProducto> MultimediasProducto { get; set; }
        public List<IFormFile>? Files { get; set; }
        public ActionTypes Action { get; set; }
    }
}
