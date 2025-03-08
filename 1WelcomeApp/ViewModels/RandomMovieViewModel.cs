using _1WelcomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie  Movie { get; set; }
        public List<Customer> Customers { get; set; }

    }
}