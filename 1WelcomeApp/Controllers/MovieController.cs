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
            //var movies = _context.Movies.Include(x => x.Genre).ToList();

            //return View(movies);

            if(User.IsInRole(UserRoles.CanManageMovies))
                return View("List");

            return View("ListOnlyRead");
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

        //[Route("movie/update/{id:int}")]

        [Authorize(Roles = UserRoles.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieViewModel = new MovieFormViewModel(movie) {
                Genres = _context.Genres.ToList()
            };


            return View("UpdateForm", movieViewModel);
        }

        [Authorize(Roles = UserRoles.CanManageMovies)]
        public ActionResult Add()
        {
            var movie = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };


            return View("UpdateForm", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres.ToList();
                return View("UpdateForm", model);
            }

            var movieLast = new Movie();

            if (model.Id > 0)
            {
                movieLast = _context.Movies.FirstOrDefault(x => x.Id == model.Id);
                if (movieLast == null )
                {
                    return HttpNotFound();
                }
            }
            else
            {
                movieLast.DateAdded = DateTime.Now;
            }

            movieLast.Name = model.Name;
            movieLast.ReleaseDate = model.ReleaseDate.Value;
            movieLast.GenreId = model.GenreId;
            movieLast.NumberInStock = model.NumberInStock.Value;
            movieLast.Genre = _context.Genres.Single(x => x.Id == model.GenreId);

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