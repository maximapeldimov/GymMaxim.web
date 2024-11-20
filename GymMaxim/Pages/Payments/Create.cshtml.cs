using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Payments
{
    public class CreateModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public CreateModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EnrollmentID"] = new SelectList(_context.Enrollments, "EnrollmentID", "EnrollmentID");
            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Payments.Add(Payment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
