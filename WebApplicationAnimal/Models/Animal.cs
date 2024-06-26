﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationAnimal.Models
{
    public class Animal
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; } = null;
        [Required]
        [MaxLength(200)]
        public string Category { get; set; }
        [Required]
        [MaxLength(200)]
        public string Area { get; set; }
        
    }
}
