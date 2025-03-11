using _1WelcomeApp.Models;
using _1WelcomeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _1WelcomeApp.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();

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

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [Route("movie/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}