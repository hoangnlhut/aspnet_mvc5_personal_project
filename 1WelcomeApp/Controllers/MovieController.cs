using _1WelcomeApp.Models;
using _1WelcomeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1WelcomeApp.Controllers
{
    public class MovieController : Controller
    {
        IEnumerable<Movie> movies = new List<Movie>()
        {
            new Movie(){ Id = 1, Name= "Phim 1", Publisher = "VN"},
            new Movie(){ Id = 2, Name= "Phim 2", Publisher = "VN"},
            new Movie(){ Id = 3, Name= "Phim 3", Publisher = "VN"},
            new Movie(){ Id = 4, Name= "Phim 4", Publisher = "VN"},

        };
        // GET: Movie
        public ActionResult Index()
        {
            return View(movies);
        }

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                //Id = 1,
                Name = "King Kong",
            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = new List<Customer>
                {
                    new Customer { Name = "Hoang 1" },
                    new Customer { Name = "Hoang 2" },
                    new Customer { Name = "Hoang 3" },
                    new Customer { Name = "Hoang 4" },
                    new Customer { Name = "Hoang 5" },
                    new Customer { Name = "Trang 2" }
                }
            };
            return View(viewModel);
        }


        [Route("edit/{id:int}")]

        public ActionResult Edit(int id = 10)
        {
            //return Content("id=" + id);
            ViewBag.MovieId = id;

            ViewData["trang"] = "Hoang";

            return View();
        }

        [Route("movie/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}