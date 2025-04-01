using _1WelcomeApp.Dtos;
using _1WelcomeApp.Models;
using _1WelcomeApp.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1WelcomeApp.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        //POST /api/rental
        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //This is pesimesstic approach with many validation checks
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null) return BadRequest("Invalid Customer");

            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No movie Ids have been given.");

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more Movies are invalid");

            foreach (var movieSingle in movies)
            {
                if (movieSingle.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movieSingle.NumberAvailable--;

                var rentalEntity = Mapper.Map<NewRentalDto, Rental>(rentalDto);


                rentalEntity.Movie = movieSingle;
                rentalEntity.Customer = customer;
                rentalEntity.DateRented = DateTime.Now;

                _context.Rentals.Add(rentalEntity);

                
            }
           
            _context.SaveChanges();

            return Ok();
        }
    }
}
