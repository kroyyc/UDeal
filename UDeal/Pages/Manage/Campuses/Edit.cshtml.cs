using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Manage.Campuses
{
    public class EditModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;

        public EditModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SchoolId"] = new SelectList(_context.Schools, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Campus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampusExists(Campus.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CampusExists(int id)
        {
            return _context.Campuses.Any(e => e.Id == id);
        }
    }
}
