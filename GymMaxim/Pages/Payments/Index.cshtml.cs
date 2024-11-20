using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public IndexModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Payment = await _context.Payments
                .Include(p => p.Enrollment).ToListAsync();
        }
    }
}
