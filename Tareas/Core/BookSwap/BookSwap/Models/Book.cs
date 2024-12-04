using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSwap.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string? Genre { get; set; }
        public bool IsAvailable { get; set; }
        [Display(Name = "Loan Date"), DataType(DataType.Date)]
        public DateTime? LoanDate { get; set; } = null;
        [Display(Name = "Return Date"), DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; } = null;
    }
}
