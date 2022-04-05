using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public CreateModel(UserManager<User> userManager, UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["UserId"] = user.Id;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
