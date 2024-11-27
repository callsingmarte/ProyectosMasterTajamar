namespace FirstCoreApp.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal GPA { get; set; }
        public Major? Major { get; set; }
    }
}
