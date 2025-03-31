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

            var customer = _context.Customers.FirstOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null) return BadRequest("Invalid Customer");

            foreach (var movieId in rentalDto.MovieIds)
            {
               var movie =  _context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (movie == null) return BadRequest("Invalid movie");


                var rentalEntity = Mapper.Map<NewRentalDto, Rental>(rentalDto);


                rentalEntity.Movie = movie;
                rentalEntity.Customer = customer;
                rentalEntity.DateRented = DateTime.Now;

                _context.Rentals.Add(rentalEntity);
            }
           
            _context.SaveChanges();

            return Ok();
        }
    }
}
