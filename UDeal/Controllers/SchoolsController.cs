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
    public class SchoolsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDTO>>> GetSchools()
        {
            return await _context.Schools
                .Select(s => ItemToDTO(s))
                .ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDTO>> GetSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return ItemToDTO(school);
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(int id, SchoolDTO schoolDTO)
        {
            if (id != schoolDTO.Id)
            {
                return BadRequest();
            }

            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            school.ShortName = schoolDTO.ShortName;
            school.Domain = schoolDTO.Domain;
            school.Name = schoolDTO.Name;

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolDTO>> PostSchool(SchoolDTO schoolDTO)
        {
            var school = new School
            {
                Id = schoolDTO.Id,
                Name = schoolDTO.Name,
                ShortName = schoolDTO.ShortName,
                Domain = schoolDTO.Domain
            };

            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, ItemToDTO(school));
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.Id == id);
        }

        private static SchoolDTO ItemToDTO(School school) =>
            new SchoolDTO
            {
                Id = school.Id,
                Name = school.Name,
                Domain = school.Domain,
                ShortName = school.ShortName
            };
    }
}
