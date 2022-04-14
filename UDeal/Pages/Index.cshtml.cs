using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Post> Posts { get; set; }

        public List<Image> Images { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public int School { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Campus { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["Schools"] = new SelectList(_context.Schools, "Id", "Name");
            ViewData["SchoolCampuses"] = new SelectList(_context.Campuses.Where(c => c.SchoolId == School), "Id", "Name");

            Images = _context.Images.ToList();

            var posts = from p in _context.Posts
                        join user in _context.Users on p.UserId equals user.Id
                        select p;

            if (!string.IsNullOrEmpty(Search))
            {
                var lowerSearch = Search.ToLower();
                posts = posts.Where(p => p.Title.ToLower().Contains(lowerSearch) || p.Description.ToLower().Contains(lowerSearch));
            }

            if (Category > 0)
            {
                posts = posts.Where(p => p.CategoryId == Category);
            }

            if (School > 0)
            {
                posts = posts.Where(p => p.User.SchoolId == School);
            }

            Posts = await posts.Include(p => p.User).ToListAsync();
        }
    }
}
