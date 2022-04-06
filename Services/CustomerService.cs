using BusinessAccessLayer.Contract;
using CommonLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services
{
    public class CustomerService : ICustomer
    {
        private CustomerDbOperation dbOperation;
        public CustomerService()
        {
            dbOperation = new CustomerDbOperation();
        }

        public Customer CreateCustomer(Customer obj)
        {
           var result = dbOperation.CreateCustomer(obj);
            return result;
        }

        public bool DeleteCustomer(int Id)
        {
            var result = dbOperation.DeleteCustomer(Id);
            return result;
        }

        public Customer GetCustomerById(int Id)
        {
            var result = dbOperation.GetCustomerById(Id);
            return result;
        }

        public List<Customer> GetCustomers()
        {
            return dbOperation.GetCustomers();
        }
        
        public Customer UpdateCustomer(Customer obj)
        {   
            var result = dbOperation.UpdateCustomer(obj);
            return result;
        }
        public Customer CustomerDetails(int Id)
        {
            var result = dbOperation.GetCustomerById(Id);
            return result;
        }
    }
}
