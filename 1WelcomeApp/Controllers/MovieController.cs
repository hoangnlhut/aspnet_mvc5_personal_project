using _1WelcomeApp.Models;
using _1WelcomeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;

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

        [Route("movie/update/{id:int}")]
        public ActionResult AddOrUpdate(int id)
        {
            var movie = new Movie();

            if (id > 0)
            {
               movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

                if (movie == null)
                {
                    return HttpNotFound();
                }
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("UpdateForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            var movieLast = movie;
            
            if (movie.Id > 0)
            {
                movieLast = _context.Movies.Single(x => x.Id == movie.Id);
                movieLast.Name = movie.Name;
                movieLast.ReleaseDate = movie.ReleaseDate;
                movieLast.GenreId = movie.GenreId;
                movieLast.NumberInStock = movie.NumberInStock;

            }
            else
            {
                movieLast.DateAdded = DateTime.Now;
            }

            movieLast.Genre = _context.Genres.Single(x => x.Id == movie.GenreId);

            _context.Movies.AddOrUpdate(movieLast);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }




        [Route("movie/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}