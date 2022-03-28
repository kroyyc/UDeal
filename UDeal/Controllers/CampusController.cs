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
    public class CampusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CampusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Campus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampusDTO>>> GetCampuses()
        {
            return await _context.Campuses
                .Select(c => ItemToDTO(c))
                .ToListAsync();
        }

        // GET: api/Campus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampusDTO>> GetCampus(int id)
        {
            var campus = await _context.Campuses.FindAsync(id);

            if (campus == null)
            {
                return NotFound();
            }

            return ItemToDTO(campus);
        }

        // PUT: api/Campus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampus(int id, CampusDTO campusDTO)
        {
            if (id != campusDTO.Id)
            {
                return BadRequest();
            }

            var campus = await _context.Campuses.FindAsync(id);

            if (campus == null) {
                return NotFound();
            }

            campus.City = campusDTO.City;
            campus.Name = campusDTO.Name;
            campus.SchoolId = campusDTO.SchoolId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampusExists(id))
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

        // POST: api/Campus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CampusDTO>> PostCampus(CampusDTO campusDTO)
        {
            var campus = new Campus
            {
                Id = campusDTO.Id,
                Name = campusDTO.Name,
                SchoolId = campusDTO.SchoolId,
                City = campusDTO.City
            };

            _context.Campuses.Add(campus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCampus), new { id = campus.Id }, ItemToDTO(campus));
        }

        // DELETE: api/Campus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampus(int id)
        {
            var campus = await _context.Campuses.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }

            _context.Campuses.Remove(campus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampusExists(int id)
        {
            return _context.Campuses.Any(e => e.Id == id);
        }

        private static CampusDTO ItemToDTO(Campus campus) =>
            new CampusDTO
            {
                Id = campus.Id,
                Name = campus.Name,
                City = campus.City,
                SchoolId = campus.SchoolId
            };
    }
}
