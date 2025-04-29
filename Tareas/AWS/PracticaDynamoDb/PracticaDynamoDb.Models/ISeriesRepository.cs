using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDynamoDb.Models
{
    public interface ISeriesRepository
    {
        Task<Serie> Single(string serieId);
        Task<SerieViewModel> All(string paginationToken = "");
        Task<IEnumerable<Serie>> Find(SearchRequest searchReq);
        Task Add(SerieInputModel entity);
        Task Remove(string serieId);
        Task Update(string serieId, SerieInputModel entity);
    }
}

