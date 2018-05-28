using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POC.Models;
using POC.ViewModels;

namespace POC.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(m =>m.MembershipType).ToList();

            return View(customers);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();


            var viewModel = new CustomerFormViewModel
            {

                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

       
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id) {
            var customer = _context.Customers.Include(m=>m.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer == null)
                return HttpNotFound();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm",viewModel);
        }
    }
}