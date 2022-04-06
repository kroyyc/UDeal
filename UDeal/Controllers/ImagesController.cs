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
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetImages()
        {
            return await _context.Images
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return ItemToDTO(image);
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutImage(int id, Image image)
        //{
        //    if (id != image.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(image).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ImageExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageDTO>> PostImage(ImageDTO imageDTO)
        {
            var image = new Image
            {
                Id = imageDTO.Id,
                Name = imageDTO.Name,
                PostId = imageDTO.PostId,
            };
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImage), new { id = image.Id }, ItemToDTO(image));
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }

        private static ImageDTO ItemToDTO(Image image) =>
            new ImageDTO
            {
                Id = image.Id,
                Name = image.Name,
                PostId = image.PostId,
            };
    }
}
