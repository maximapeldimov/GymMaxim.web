using Microsoft.EntityFrameworkCore;
using GymMaxim.Models;

namespace GymMaxim.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}