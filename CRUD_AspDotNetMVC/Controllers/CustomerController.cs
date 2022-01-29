using CRUD_AspDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_AspDotNetMVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccess_Layer objCustomer = new CustomerDataAccess_Layer();
        [HttpGet]
        public IActionResult Create_customer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_customer([Bind] Customer cust)
        {
            if (ModelState.IsValid)
            {
                objCustomer.AddCustomer(cust);
                return RedirectToAction("Index");
            }
            return View(objCustomer);
        }
        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            customers = objCustomer.GetAllCustomers().ToList();
            return View(customers);
        }
        public IActionResult Edit_customer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = objCustomer.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit_customer(int id, [Bind] Customer cust)
        {
            if (id != cust.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objCustomer.UpdateCustomer(cust);
                return RedirectToAction("Index");
            }
            return View(objCustomer);
        }
        [HttpGet]
        public IActionResult customer_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer objcustomer = objCustomer.GetCustomerData(id);

            if (objcustomer == null)
            {
                return NotFound();
            }
            return View(objcustomer);
        }
        [HttpGet]
        public IActionResult Delete_customer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer objcustomer = objCustomer.GetCustomerData(id);

            if (objcustomer == null)
            {
                return NotFound();
            }
            return View(objcustomer);
        }

        [HttpPost, ActionName("Delete_customer")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objCustomer.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
