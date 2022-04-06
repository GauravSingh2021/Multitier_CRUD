using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
   public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="* Enter your FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="* Enter your LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="* Enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="* Enter your Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage ="* Enter your Address")]
        public string Address { get; set; }
    }
}
