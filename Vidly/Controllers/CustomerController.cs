﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DomainModels;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
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
            base.Dispose(disposing);
        }

        public ActionResult New()
        {
            var viewModel = new FormCustomerViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("Form", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Id = customer.Id;
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter; 
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new FormCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("Form", viewModel);
        }
    }
}