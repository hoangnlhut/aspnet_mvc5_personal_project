using _1WelcomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1WelcomeApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                //Id = 1,
                Name = "Test",
            };
            return View(movie);
        }
    }
}