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
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public School School { get; set; }
        public int NumUsers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            School = await _context.Schools.FirstOrDefaultAsync(m => m.Id == id);
            NumUsers = await _context.Users.Where(u => u.SchoolId == School.Id).CountAsync();

            if (School == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
