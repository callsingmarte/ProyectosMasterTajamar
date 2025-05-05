using System.ComponentModel.DataAnnotations;

namespace Publicaciones.ViewModels
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
