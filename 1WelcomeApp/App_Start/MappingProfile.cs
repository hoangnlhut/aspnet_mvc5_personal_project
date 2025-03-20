using _1WelcomeApp.Dtos;
using _1WelcomeApp.Models;
using AutoMapper;
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
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}