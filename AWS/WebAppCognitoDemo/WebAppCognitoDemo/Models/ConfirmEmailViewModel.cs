using System.ComponentModel.DataAnnotations;

namespace WebAppCognitoDemo.Models
{
    public class ConfirmEmailViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Código de confirmación")]
        public string? Code { get; set; }
    }
}
