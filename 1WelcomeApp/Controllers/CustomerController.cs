using _1WelcomeApp.Models;
using _1WelcomeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1WelcomeApp.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            CustomerViewModel viewModel = new CustomerViewModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList(),
            };

            return View(viewModel);
        }

        // GET: Customer/Edit/5
        [Route("customer/edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            var customer = 
                _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

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
