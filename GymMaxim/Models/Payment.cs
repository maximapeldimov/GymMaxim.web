
using System;

namespace GymMaxim.Models
{
    public enum PaymentType
    {
        CreditCard, Shek, Cash
    }
    public class Payment
    {
        public int PaymentID { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int amount { get; set; }

        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}