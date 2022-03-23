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
    public class DetailsModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;

        public DetailsModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Campus Campus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus = await _context.Campuses
                .Include(c => c.School).FirstOrDefaultAsync(m => m.Id == id);

            if (Campus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
