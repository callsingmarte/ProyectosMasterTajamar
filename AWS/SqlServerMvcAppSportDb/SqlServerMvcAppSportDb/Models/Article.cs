namespace SqlServerMvcAppSportDb.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
