using System.ComponentModel.DataAnnotations;

namespace Smith_Swimming_School.Models
{
    public class Group
    {
        [Key]
        public int Id_Grouping { get; set; }
        public Level Level { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Start_Date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime End_Date { get; set; }
        public int Places { get; set; }
    }

    public enum Level
    {
        SwimmerLvl1 = 1, 
        SwimmerLvl2, 
        SwimmerLvl3, 
        SwimmerLvl4, 
        SwimmerLvl5, 
        SwimmerLvl6
    }
}
