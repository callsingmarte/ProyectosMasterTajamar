using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Publicaciones.Interfaces;
using Publicaciones.Models;
using Publicaciones.ViewModels;
using System.Security.Claims;

namespace Publicaciones.Services
{
    public class PublicacionesRepository : IpublicacionesRepository
    {
        private readonly DynamoDBContext _context;

        public PublicacionesRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task Add(PublicacionInputModel entity, string userId)
        {
            var publicacion = new Publicacion
            {
                UserId = userId,
                PublicacionId = Guid.NewGuid(),
                Titulo = entity.Titulo,
                Contenido = entity.Contenido,
                FechaCreacion = entity.FechaCreacion,
            };

            await _context.SaveAsync(publicacion);           
        }

        public async Task<IEnumerable<Publicacion>> Find(SearchRequest searchReq, string userId)
        {
            var scanConditions = new List<ScanCondition>();

            if (!string.IsNullOrEmpty(searchReq.Titulo)) 
            {
                scanConditions.Add(new ScanCondition("Titulo", ScanOperator.Equal, searchReq.Titulo));
            }

            if (!string.IsNullOrEmpty(searchReq.FechaCreacion.ToString())) 
            {
                scanConditions.Add(new ScanCondition("FechaCreacion", ScanOperator.Equal, searchReq.FechaCreacion));
            }

            scanConditions.Add(new ScanCondition("UserId", ScanOperator.Equal, userId));

            return await _context.ScanAsync<Publicacion>(scanConditions).GetRemainingAsync();
        }

        public async Task Remove(Guid publicacionId)
        {
            await _context.DeleteAsync<Publicacion>(publicacionId);
        }

        public async Task<Publicacion> Single(Guid publicacionId)
        {
            return await _context.LoadAsync<Publicacion>(publicacionId);
        }

        public async Task Update(Guid publicacionId, PublicacionInputModel entity)
        {
            var publicacion = await Single(publicacionId);

            publicacion.Titulo = entity.Titulo;
            publicacion.Contenido = entity.Contenido;
            
            await _context.SaveAsync<Publicacion>(publicacion);
        }

        public async Task<PublicacionViewModel> UserPublicaciones(string userId)
        {
            List<Publicacion> publicaciones = await _context.ScanAsync<Publicacion>(
                new List<ScanCondition>() { new ScanCondition("UserId", ScanOperator.Equal, userId) }
                ).GetRemainingAsync();

            return new PublicacionViewModel
            {
                Publicaciones = publicaciones,
                ResultsType = ResultsType.List
            };
        }
    }
}
