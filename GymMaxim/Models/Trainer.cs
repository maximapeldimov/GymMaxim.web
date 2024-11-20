namespace GymMaxim.Models
{
 
    public enum Gender
    {
        Male, Female
    }
    public class Trainer
    {
        public int TrainerID { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }

        public Gender Gender { get; set; }
    }
}