using _1WelcomeApp.Models;
using _1WelcomeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
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
            //CustomerViewModel viewModel = new CustomerViewModel
            //{
            //    Customers = _context.Customers.Include(c => c.MembershipType).ToList(),
            //};

            //return View(viewModel);
            return View();
        }


        [Route("customer/update/{id:int}")]
        public ActionResult AddOrUpdate(int? id)
        {
            var customer = new Customer();
            if (id > 0)
            {
                customer =
              _context.Customers
              .SingleOrDefault(c => c.Id == id);

                if (customer == null) return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }

        #region Edit and New To become one
        // GET: Customer/Edit/5
        [Route("customer/edit/{id:int}")]
        //public ActionResult Edit(int? id)
        //{

        //    var customer =
        //        _context.Customers
        //        .SingleOrDefault(c => c.Id == id);

        //    if (customer == null) return HttpNotFound();


        //    var viewModel = new CustomerFormViewModel
        //    {
        //        Customer = customer,
        //        MembershipTypes = _context.MembershipTypes.ToList()
        //    };

        //    return View("New", viewModel);
        //}


        //public ActionResult New()
        //{
        //    var membershipTypes = _context.MembershipTypes.ToList();

        //    var viewModel = new CustomerFormViewModel
        //    {
        //        MembershipTypes = membershipTypes
        //    };
        //    return View(viewModel);
        //}
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Customer.Name) || model.Customer.MembershipTypeId <= 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad request");

                var customer = model.Customer;

                if (model.Customer.Id > 0)
                {
                    customer = _context.Customers.FirstOrDefault(x => x.Id == model.Customer.Id);
                    if (customer == null) return HttpNotFound();


                    //in the future we can use Automapper to map ModelDto to data 
                    customer.Name = model.Customer.Name;
                    customer.Birthdate = model.Customer.Birthdate;
                    customer.IsSubsribedToNewsletter = model.Customer.IsSubsribedToNewsletter;
                    customer.MembershipTypeId = model.Customer.MembershipTypeId;

                }

                customer.MembershipType = _context.MembershipTypes.Single(x => x.Id == model.Customer.MembershipTypeId);

                _context.Customers.AddOrUpdate(customer);
                _context.SaveChanges();

                return RedirectToAction("Index", "Customer");
            }

            

            var viewModel = new CustomerFormViewModel() { 
            Customer = model.Customer,
              MembershipTypes = _context.MembershipTypes.ToList(),
            };    
           return View("New", viewModel);
        }


        //// GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

    }

   
}
