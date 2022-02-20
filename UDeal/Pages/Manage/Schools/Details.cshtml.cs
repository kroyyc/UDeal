using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Manage.Schools
{
    public class DetailsModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;

        public DetailsModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public School School { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            School = await _context.Schools.FirstOrDefaultAsync(m => m.Id == id);

            if (School == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
