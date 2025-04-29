using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using PracticaDynamoDb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaDynamoDb.Core
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public SeriesRepository()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext();
        }

        public async Task Add(SerieInputModel entity)
        {
            var serie = new Serie
            {
                SerieId = Guid.NewGuid().ToString(),
                Titulo = entity.Titulo,
                Genero = entity.Genero,
                Temporadas = entity.Temporadas,
                DisponibleEn = entity.DisponibleEn
            };

            await _context.SaveAsync(serie);
        }

        public async Task<SerieViewModel> All(string paginationToken = "")
        {
            var table = _context.GetTargetTable<Serie>();

            var scanOps = new ScanOperationConfig();

            if (!string.IsNullOrEmpty(paginationToken))
            {
                scanOps.PaginationToken = paginationToken;
            }

            var results = table.Scan(scanOps);

            List<Document> data = await results.GetNextSetAsync();

            IEnumerable<Serie> series = _context.FromDocuments<Serie>(data);

            return new SerieViewModel
            {
                PaginationToken = results.PaginationToken,
                Series = series,
                ResultsType = ResultsType.List
            };
        }

        public async Task<IEnumerable<Serie>> Find(SearchRequest searchReq)
        {
            var scanConditions = new List<ScanCondition>();

            if (!string.IsNullOrEmpty(searchReq.Titulo))
            {
                scanConditions.Add(new ScanCondition("Titulo", ScanOperator.Equal, searchReq.Titulo));
            }
            if (!string.IsNullOrEmpty(searchReq.Genero))
            {
                scanConditions.Add(new ScanCondition("Genero", ScanOperator.Equal, searchReq.Genero));
            }
            if(searchReq.Temporadas > 0)
            {
                scanConditions.Add(new ScanCondition("Temporadas", ScanOperator.Equal, searchReq.Temporadas));
            }
            if (!string.IsNullOrEmpty(searchReq.DisponibleEn))
            {
                scanConditions.Add(new ScanCondition("DisponibleEn", ScanOperator.Equal, searchReq.DisponibleEn));
            }

            return await _context.ScanAsync<Serie>(scanConditions, null).GetRemainingAsync();
        }

        public async Task Remove(string serieId)
        {
            await _context.DeleteAsync<Serie>(serieId);
        }

        public async Task<Serie> Single(string serieId)
        {
            return await _context.LoadAsync<Serie>(serieId);
        }

        public async Task Update(string serieId, SerieInputModel entity)
        {
            var serie = await Single(serieId);

            serie.Titulo = entity.Titulo;
            serie.Genero = entity.Genero;
            serie.Temporadas = entity.Temporadas;
            serie.DisponibleEn = entity.DisponibleEn;

            await _context.SaveAsync<Serie>(serie);
        }
    }
}
