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

        public IndexModel(UserManager<User> userManager, UDeal.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Post = await _context.Posts.Where(p => p.UserId.Equals(user.Id)).Include(p => p.Category).ToListAsync();
        }
    }
}
