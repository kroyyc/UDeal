using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            return await _context.Courses
                .Select(c => ItemToDTO(c))
                .ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id, int Schoolid)
        {
            var course = await _context.Courses.FindAsync(id, Schoolid);

            if (course == null)
            {
                return NotFound();
            }

            return ItemToDTO(course);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, int Schoolid, CourseDTO courseDTO)
        {
            if (id != courseDTO.Id || Schoolid != courseDTO.SchoolId)
            {
                return BadRequest();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            course.SchoolId = courseDTO.SchoolId;
            course.Name = courseDTO.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDTO>> PostCourse(CourseDTO courseDTO)
        {
            var course = new Course
            {
                Name = courseDTO.Name,
                SchoolId = courseDTO.SchoolId,
                School = _context.Schools.Find(courseDTO.SchoolId)
            };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id },ItemToDTO(course));
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id, int Schoolid)
        {
            var course = await _context.Courses.FindAsync(id, Schoolid);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        private static CourseDTO ItemToDTO(Course course) =>
            new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                SchoolId = course.SchoolId,
            };
    }
}
