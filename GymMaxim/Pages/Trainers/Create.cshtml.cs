﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Trainers
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
            return Page();
        }

        [BindProperty]
        public Trainer Trainer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trainers.Add(Trainer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
