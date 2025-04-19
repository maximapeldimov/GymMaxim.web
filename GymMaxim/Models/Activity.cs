using System.Collections.Generic;

namespace GymMaxim.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string ActivityType { get; set; }
        public double Price { get; set; }
        public string WorkDays { get; set; }
        public int TrainerID { get; set; }

        public string Image { get; set; }

        public Trainer Trainer { get; set; }
        
    }
}