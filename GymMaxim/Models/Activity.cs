using System.Collections.Generic;

namespace GymMaxim.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public int TrainerID { get; set; }

        public Trainer Trainer { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}