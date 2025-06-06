﻿using System.ComponentModel.DataAnnotations;

namespace PracticaAwsSnS.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contrasena { get; set; }
    }
}
