using Publicaciones.Models;
using Publicaciones.ViewModels;

namespace Publicaciones.Interfaces
{
    public interface IpublicacionesRepository
    {
        Task<Publicacion> Single(Guid publicacionId);
        Task<PublicacionViewModel> UserPublicaciones(string userId);
        Task<IEnumerable<Publicacion>> Find(SearchRequest searchReq, string userId);
        Task Add(PublicacionInputModel entity, string userId);
        Task Remove(Guid publicacionId);
        Task Update(Guid publicacionId, PublicacionInputModel entity);
    }
}
