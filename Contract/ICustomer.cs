using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Contract
{
   public interface ICustomer
    {
        List<Customer> GetCustomers();
        Customer CreateCustomer(Customer obj);
        bool DeleteCustomer(int Id);
        Customer GetCustomerById(int Id);
        Customer UpdateCustomer(Customer obj);
        Customer CustomerDetails(int Id);
    }
}
