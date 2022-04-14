using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(UserManager<User> userManager, UDeal.Data.ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> OnGetAsync(int type)
        {
            ViewData["Type"] = type;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["UserId"] = user.Id;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SchoolCampuses"] = new SelectList(_context.Campuses.Where(c => c.SchoolId == user.SchoolId), "Id", "Name");
            ViewData["SchoolCourses"] = _context.Courses.Where(c => c.SchoolId == user.SchoolId).ToList();
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public string CourseName { get; set; }
      
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!string.IsNullOrEmpty(CourseName))
            {
                CourseName = CourseName.ToUpper().Trim();
                Course course = _context.Courses.Where(c => c.Name == CourseName).FirstOrDefault();
                // Check if this course already exists
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
                        School = user.School
                    };
                    _context.Courses.Add(course);
                    Post.Course = course;
                }
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            string filePath = ProcessUploadedFile();
            var image = new Image
            {
                Name = filePath,
                Post = Post,
                PostId = Post.Id
            };
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Posts/Index");
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
