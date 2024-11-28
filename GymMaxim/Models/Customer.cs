
using System;
using System.ComponentModel;
using System.Data;

namespace GymMaxim.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCard { get; set; }
        public Gender?  Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Street { get; set; } 
        public int HomeNumber { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }

    }
}