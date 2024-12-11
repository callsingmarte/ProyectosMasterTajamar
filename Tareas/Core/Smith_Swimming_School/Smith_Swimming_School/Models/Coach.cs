using System.ComponentModel.DataAnnotations;

namespace Smith_Swimming_School.Models
{
    public class Coach
    {
        [Key]
        public int Id_Coach { get; set; }
        public string? Name { get; set; }
        public string? Phone_Number { get; set; }
    }
}
