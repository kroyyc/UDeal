using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Manage.Campuses
{
    public class CreateModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;

        public CreateModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SchoolId"] = new SelectList(_context.Schools, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Campus Campus { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Campuses.Add(Campus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
