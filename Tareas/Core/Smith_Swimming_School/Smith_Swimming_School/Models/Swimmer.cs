using System.ComponentModel.DataAnnotations;

namespace Smith_Swimming_School.Models
{
    public class Swimmer
    {
        public int Id_Swimmer { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Phone_Number { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birth_Date { get; set; }
    }

    public enum Genre
    {
        Man = 1,
        Woman
    }
}
