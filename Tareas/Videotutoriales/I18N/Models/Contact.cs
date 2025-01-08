using System.ComponentModel.DataAnnotations;

namespace I18N.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "The Phone field is required.")]
        [StringLength(9, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "The Message field is required.")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 50)]
        public string? Message { get; set; }
    }
}
