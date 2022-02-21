using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Manage.Schools
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;

        public IndexModel(UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<School> School { get;set; }
        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            School = await _context.Schools.ToListAsync();
            Users = await _context.Users.ToListAsync(); 
        }
    }
}
