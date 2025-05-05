using Amazon.DynamoDBv2.DataModel;

namespace Publicaciones.Models
{
    public class PublicacionInputModel
    {
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public InputType InputType { get; set; }
    }
}
