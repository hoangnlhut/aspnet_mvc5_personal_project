using _1WelcomeApp.Models;
using _1WelcomeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1WelcomeApp.Controllers
{
    public class CustomerController : Controller
    {
        //hard code fist, then we will use database
        private List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Hoang", Address = "Viet Nam" },
             new Customer { Id = 2, Name = "John", Address = "My" },
              new Customer { Id = 3, Name = "Trang", Address = "Phu Tho" },
               new Customer { Id = 4, Name = "Viet", Address = "Africa" },
        };

        // GET: Customer
        public ActionResult Index()
        {
            CustomerViewModel viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Customer/Edit/5
        [Route("customer/edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var customer = customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }


        //// POST: Customer/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

    }
}
