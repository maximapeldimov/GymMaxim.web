using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Activities
{
    public class IndexModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public IndexModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Activity> ActivitiesIQ = from s in _context.Activities select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                ActivitiesIQ = ActivitiesIQ.Where(s => s.ActivityName.Contains(SearchString));
            }

            Activity = await ActivitiesIQ.Include(a => a.Trainer).ToListAsync();
            //Activity = await _context.Activities
                //.Include(a => a.Trainer).ToListAsync();
        }
    }
}
