﻿using System.ComponentModel.DataAnnotations;

namespace _1WelcomeApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}