﻿
using System;

namespace GymMaxim.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public int ActivityID { get; set; }
        public int CustomerID { get; set; }
        public Activity Activity { get; set; }
        public Customer Customer { get; set; }
    }
}