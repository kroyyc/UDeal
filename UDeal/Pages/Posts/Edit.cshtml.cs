using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public EditModel(UserManager<User> userManager, UDeal.Data.ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Post Post { get; set; }
        [BindProperty]
        public string CourseName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["UserId"] = user.Id;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SchoolCourses"] = _context.Courses.Where(c => c.SchoolId == user.SchoolId).ToList();
            ViewData["SchoolCampuses"] = new SelectList(_context.Campuses.Where(c => c.SchoolId == user.SchoolId), "Id", "Name");

            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Post == null)
            {
                return NotFound();
            }

            if (Post.Course != null)
            {
                CourseName = Post.Course.Name;
            }

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

            if(!string.IsNullOrEmpty(CourseName)) 
            {
                CourseName = CourseName.ToUpper().Trim();       // normalize
                if (Post.Course == null || CourseName != Post.Course.Name)
                {
                    // user changed the course input field, so check if exists...
                    Course course = _context.Courses.Where(c => c.Name == CourseName).FirstOrDefault();
                    if (course != null)
                    {
                        Post.Course = course;
                        Post.CourseId = course.Id;
                    }
                    else
                    {
                        var user = await _userManager.FindByNameAsync(User.Identity.Name);
                        // else add the course to the database
                        course = new Course
                        {
                            Name = CourseName,
                            SchoolId = (int)user.SchoolId,
                        };
                        _context.Courses.Add(course);
                        Post.Course = course;
                    }
                }
            }
            _context.Attach(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.Id))
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

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
