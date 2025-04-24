using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDynamoDb.Models
{
    public class Serie
    {
        public string SerieId { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Temporadas { get; set; }
        public string DisponibleEn { get; set; } //Lo puedes hacer enum
    }
}
