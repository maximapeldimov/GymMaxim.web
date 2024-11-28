using System;
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
    public class IndexModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public IndexModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Trainer> Trainer { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Trainer> TrainersIQ = from s in _context.Trainers select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                TrainersIQ = TrainersIQ.Where(s => s.LastName.Contains(SearchString) || s.FirstName.Contains(SearchString));
            }

            Trainer = await TrainersIQ.ToListAsync();
            //Trainer = await _context.Trainers.ToListAsync();
        }
    }
}
