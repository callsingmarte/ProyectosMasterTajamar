using System.ComponentModel.DataAnnotations;

namespace MvcKmsDemo.Models
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string EncryptedText { get; set; } = string.Empty;

    }
}
