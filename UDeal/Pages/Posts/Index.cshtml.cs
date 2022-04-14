using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(UserManager<User> userManager, UDeal.Data.ApplicationDbContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                Post = await _context.Posts
                    .Where(p => p.UserId.Equals(user.Id))
                    .Include(p => p.Category)
                    .Include(c => c.Course)
                    .ToListAsync();
            }
        }
    }
}
