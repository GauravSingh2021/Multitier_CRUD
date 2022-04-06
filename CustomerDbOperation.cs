using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
   public class CustomerDbOperation
    {
        private DbConnect dbConnect;
        public CustomerDbOperation()
        {
            dbConnect = new DbConnect();
        }
        public List<Customer> GetCustomers()
        {
            SqlCommand command = new SqlCommand("Sp_Customer", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "SELECT");
            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while(dr.Read())
                {
                Customer obj = new Customer();
                obj.Id = (int)dr["Id"];
                obj.FirstName = dr["FirstName"].ToString();
                obj.LastName = dr["LastName"].ToString();
                obj.Email = dr["Email"].ToString();
                obj.Mobile = dr["Mobile"].ToString();
                obj.Address = dr["Address"].ToString();
                customers.Add(obj);

            }
            dbConnect.connection.Close();
            return customers;
        }

        public Customer CreateCustomer(Customer customer)
        {
            SqlCommand command = new SqlCommand("Sp_Customer", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "CREATE");
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Mobile", customer.Mobile);
            command.Parameters.AddWithValue("@Address", customer.Address);

            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            var result = (int)command.ExecuteScalar();
            dbConnect.connection.Close();
            if(result==1)
            {
                return customer;
            }
            else
            {
                return null;
            }

        }

        public Customer GetCustomerById(int Id)
        {
            SqlCommand command = new SqlCommand("Sp_Customer", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "SELECT_SINGLE");
            command.Parameters.AddWithValue("@Id", Id);

            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            Customer obj = new Customer();
            obj.Id = (int)dr["Id"];
            obj.FirstName = dr["FirstName"].ToString();
            obj.LastName = dr["LastName"].ToString();
            obj.Email = dr["Email"].ToString();
            obj.Mobile = dr["Mobile"].ToString();
            obj.Address = dr["Address"].ToString();

            dbConnect.connection.Close();
            return obj;
        }

        public bool DeleteCustomer(int Id)
        {
            SqlCommand command = new SqlCommand("Sp_Customer", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "DELETE");
            command.Parameters.AddWithValue("@Id", Id);

            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            int I = (int)command.ExecuteScalar();
           

            dbConnect.connection.Close();
            if (I == 1)
                return true;
            else
                return false;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            SqlCommand command = new SqlCommand("Sp_Customer", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "UPDATE");
            command.Parameters.AddWithValue("@Id", customer.Id);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Mobile", customer.Mobile);
            command.Parameters.AddWithValue("@Address", customer.Address);

            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            var select = (int)command.ExecuteScalar();

            dbConnect.connection.Close();
            if (select == 1)
                return customer;
            else
                return null;
            
        }
       
        }
}
