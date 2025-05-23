﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Activities
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
        ViewData["TrainerID"] = new SelectList(_context.Trainers, "TrainerID", "FirstName");
            return Page();
        }

        [BindProperty]
        public Activity Activity { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Activities.Add(Activity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
