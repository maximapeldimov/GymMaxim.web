﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Trainers
{
    public class DeleteModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public DeleteModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trainer Trainer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainers.FirstOrDefaultAsync(m => m.TrainerID == id);

            if (trainer == null)
            {
                return NotFound();
            }
            else
            {
                Trainer = trainer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer != null)
            {
                Trainer = trainer;
                _context.Trainers.Remove(Trainer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
