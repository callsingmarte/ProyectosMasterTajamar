using System.Collections.Generic;

namespace PracticaDynamoDb.Models
{
    public class SerieViewModel
    {
        public IEnumerable<Serie> Series { get; set; }
        public ResultsType ResultsType { get; set; }
        public string PaginationToken { get; set; }
    }
}
