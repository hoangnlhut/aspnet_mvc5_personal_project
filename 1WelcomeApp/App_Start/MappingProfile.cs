using _1WelcomeApp.Dtos;
using _1WelcomeApp.Models;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.App_Start
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            //Dto To Domain
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            //Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();


        }
    }
}