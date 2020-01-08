using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;
        
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            string userId = User.Identity.GetUserId();
            var customer = context.Customer.Where(c => c.ApplicationId == userId).SingleOrDefault();
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                string userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                context.Customer.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = context.Customer.Find(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer updatedCustomer = context.Customer.Find(id);
                updatedCustomer.FirstName = customer.FirstName;
                updatedCustomer.LastName = customer.LastName;
                updatedCustomer.PickUpDay = customer.PickUpDay;
                updatedCustomer.ExtraPickUpDay = customer.ExtraPickUpDay;
                updatedCustomer.StreetAddress = customer.StreetAddress;
                updatedCustomer.City = customer.City;
                updatedCustomer.State = customer.State;
                updatedCustomer.ZipCode = customer.ZipCode;
                updatedCustomer.SuspendStart = customer.SuspendStart;
                updatedCustomer.SuspendEnd = customer.SuspendEnd;
                context.SaveChanges();

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
    }
}
