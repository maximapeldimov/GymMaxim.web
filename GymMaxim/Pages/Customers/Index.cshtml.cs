using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMaxim.Data;
using GymMaxim.Models;

namespace GymMaxim.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly GymMaxim.Data.GymContext _context;

        public IndexModel(GymMaxim.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Customer> CustomersIQ = from s in _context.Customers select s;
            if(!string.IsNullOrEmpty(SearchString) )
            {
                CustomersIQ = CustomersIQ.Where(s => s.LastName.Contains(SearchString) || s.FirstName.Contains(SearchString));
            }

            Customer = await CustomersIQ.ToListAsync();
            Customer = await _context.Customers
                .Include(e => e.Category).ToListAsync();


        }
    }
}
