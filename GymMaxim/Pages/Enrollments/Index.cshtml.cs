﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public IndexModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Enrollment> EnrollmentsIQ = from s in _context.Enrollments select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                EnrollmentsIQ = EnrollmentsIQ.Where(s => s.Customer.IdentityCard.Contains(SearchString));
            }

            Enrollment = await EnrollmentsIQ.Include(e => e.Activity)
               .Include(e => e.Customer).ToListAsync();
            //Enrollment = await _context.Enrollments
               // .Include(e => e.Activity)
              // .Include(e => e.Customer).ToListAsync();
        }
    }
}
