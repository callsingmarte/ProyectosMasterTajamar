using Publicaciones.Models;
using Publicaciones.ViewModels;

namespace Publicaciones.Interfaces
{
    public interface IpublicacionesRepository
    {
        Task<Publicacion> Single(string userId, string publicacionId);
        Task<PublicacionViewModel> UserPublicaciones(string userId);
        Task<IEnumerable<Publicacion>> Find(SearchRequest searchReq, string userId);
        Task Add(PublicacionInputModel entity, string userId);
        Task Remove(string userId, string publicacionId);
        Task Update(string userId, string publicacionId, PublicacionInputModel entity);
    }
}
