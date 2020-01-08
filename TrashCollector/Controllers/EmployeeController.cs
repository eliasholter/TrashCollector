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

        public ActionResult Details(int id)
        {
            return View();
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
                return RedirectToAction("Index", "Employee");
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
    }
}
