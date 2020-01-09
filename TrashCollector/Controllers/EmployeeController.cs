using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;

        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = DateTime.Today.DayOfWeek.ToString();
            var employee = context.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }

        public ActionResult Details()
        {
            string userId = User.Identity.GetUserId();
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode)).ToList();
            return View(customersOnRoute);
        }

        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                employee.ApplicationId = userId;
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Customer customer = context.Customer.Find(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                Customer updatedCustomer = context.Customer.Find(id);
                updatedCustomer.PickUpConfirmation = customer.PickUpConfirmation;

                if(customer.PickUpConfirmation == true)
                {
                    updatedCustomer.Balance += (15 + customer.Balance);
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CustomerLocation(int id)
        {
            Customer customer = context.Customer.Find(id);
            GeoCoderAddress geoCoder = new GeoCoderAddress();
            var splitAddress = customer.StreetAddress.Split(new[] { ' ' }, 4);
            geoCoder.address += splitAddress[0] + "+" + splitAddress[1] + "+" + splitAddress[2] + "+" + splitAddress[3] + "+" + customer.City + "+" + customer.State;
            return View(geoCoder);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Monday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Monday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
        public ActionResult Tuesday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Tueday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
        public ActionResult Wednesday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Wednesday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
        public ActionResult Thursday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Thursday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
        public ActionResult Friday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Friday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
        public ActionResult Saturday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Saturday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
        public ActionResult Sunday()
        {
            string userId = User.Identity.GetUserId();
            string currentDay = "Sunday";
            var employee = context.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var customersOnRoute = context.Customer.Where(c => (c.ZipCode == employee.ZipCode) && (currentDay == c.PickUpDay)).ToList();
            return View(customersOnRoute);
        }
    }
}
