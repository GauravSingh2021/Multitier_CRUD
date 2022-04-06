using BusinessAccessLayer.Contract;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multitierapp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer customerService;
        public CustomerController(ICustomer customer)
        {
            customerService = customer;
        }
        public IActionResult Index()
        {
            var customers = customerService.GetCustomers();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            if(ModelState.IsValid)
            {
                var result = customerService.CreateCustomer(obj);
                if(result!=null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in customer create !");
                    return View(obj);
                }
                
            }
            return View(obj);
        }
        public IActionResult Delete(int Id)
        {
            var result = customerService.DeleteCustomer(Id);
            if(result)
            {
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.message = "Error while deleting the record !";
                return RedirectToAction("Index");
            }
        }
        public IActionResult UpdateRecord(int Id)
        {
            var result = customerService.GetCustomerById(Id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateRecord(Customer model)
        {
            customerService.UpdateCustomer(model);
            return RedirectToAction("Index");
        }
        public IActionResult CustomerDetails(int Id)
        {
            var list = customerService.GetCustomerById(Id);
            return View(list);
        }
    }
}
