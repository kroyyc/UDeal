using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IndexModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts
                .Include(p => p.Campus)
                .Include(p => p.Category)
                .Include(p => p.Course)
                .Include(p => p.User).ToListAsync();
        }
    }
}
