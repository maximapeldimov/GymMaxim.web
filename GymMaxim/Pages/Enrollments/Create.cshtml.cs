using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Enrollments
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
        ViewData["ActivityID"] = new SelectList(_context.Activities, "ActivityID", "ActivityName");
        ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "IdentityCard");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
