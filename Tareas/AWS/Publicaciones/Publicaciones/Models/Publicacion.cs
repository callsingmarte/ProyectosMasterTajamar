using Amazon.DynamoDBv2.DataModel;

namespace Publicaciones.Models
{
    [DynamoDBTable("publicaciones")]
    public class Publicacion
    {
        [DynamoDBProperty("userId")]
        [DynamoDBHashKey]
        public string? UserId { get; set; }
        [DynamoDBProperty("publicacionId")]
        public Guid PublicacionId { get; set; }
        [DynamoDBProperty("titulo")]
        public string? Titulo { get; set; }
        [DynamoDBProperty("contenido")]
        public string? Contenido { get; set; }
        [DynamoDBProperty("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
    }
}
