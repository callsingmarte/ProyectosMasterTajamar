using Publicaciones.Models;

namespace Publicaciones.ViewModels
{
    public class PublicacionViewModel
    {
        public IEnumerable<Publicacion> Publicaciones { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public ResultsType ResultsType { get; set; }
    }
}
