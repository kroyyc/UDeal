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

namespace UDeal.Pages.Moderate.Posts
{
    public class IndexModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(UDeal.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            

            IQueryable<Post> posts = _context.Posts
                .Include(p => p.Campus)
                .Include(p => p.Category)
                .Include(p => p.Course)
                .Include(p => p.User);

            if (User.IsInRole("Moderator") && !User.IsInRole("Admin"))   // check if user is mod but not admin
            {
                var moderator = await _userManager.FindByNameAsync(User.Identity.Name);
                posts = posts.Where(p => p.User.SchoolId.Equals(moderator.SchoolId)); 

            }

            Post = await posts.OrderBy(p => p.Created).ToListAsync();
        }
    }
}
