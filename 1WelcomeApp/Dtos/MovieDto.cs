using _1WelcomeApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace _1WelcomeApp.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }

    }
}