using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMaxim.Data;
using GymMaxim.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymMaxim.Pages.Enrollments
{
    public class SpecificEnrollmentsModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public SpecificEnrollmentsModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public string CustomerName { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            CustomerName = $"{customer.FirstName} {customer.LastName}";

            Enrollments = await _context.Enrollments
                .Where(e => e.CustomerID == customerId)
                .Include(e => e.Activity)
                .ToListAsync();

            return Page();
        }
    }
}
