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
        YoungSwimmerLvl1 = 1,
        YoungSwimmerLvl2,
        YoungSwimmerLvl3,
        YoungSwimmerLvl4,
        YoungSwimmerLvl5,
        YoungSwimmerLvl6,
        AdultLearning,
        AdultBegginner,
        AdultLowIntermediate,
        AdultHighIntermediate,
        AdultAdvance,
        AdultTriathlón,
        AdultMaster
    }
}
