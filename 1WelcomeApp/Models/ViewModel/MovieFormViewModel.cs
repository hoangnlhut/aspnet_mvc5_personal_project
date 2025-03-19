using _1WelcomeApp.Models.CustomValidationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1WelcomeApp.Models
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Movie's Name")]
        [StringLength(255)]
        public string Name { get; set; }


        [ReleaseDateRule]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }



        [Required(ErrorMessage = "Please enter Movie's Number In Stock")]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }



        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please enter Movie's Genre")]
        public byte GenreId { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0 ? "Edit Movie" : "New Movie");
            }
        }


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}