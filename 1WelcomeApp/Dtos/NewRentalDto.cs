using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1WelcomeApp.Dtos
{
    public class NewRentalDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Movies")]
        public List<int> MovieIds { get; set; }

        [Display(Name = "Date of Rent")]
        public DateTime DateRented { get; set; }

        [Display(Name = "Date of Return")]
        public DateTime? DateReturned { get; set; }
    }
}