﻿using _1WelcomeApp.Models.CustomValidationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
       
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }
        
        public byte GenreId { get; set; }

        public int? NumberAvailable { get; set; }

    }
}