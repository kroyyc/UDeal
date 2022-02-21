using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Manage.Campuses
{
    public class IndexModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;

        public IndexModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Campus> Campus { get;set; }

        public async Task OnGetAsync()
        {
            Campus = await _context.Campuses
                .Include(c => c.School).ToListAsync();
        }
    }
}
