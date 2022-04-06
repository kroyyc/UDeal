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
    public class FavouritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Favourites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavouriteDTO>>> GetFavs()
        {
            return await _context.Favs
                .Select(f => ItemToDTO(f))
                .ToListAsync();
        }

        // GET: api/Favourites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavouriteDTO>> GetFavourite(string id)
        {
            var favourite = await _context.Favs.FindAsync(id);

            if (favourite == null)
            {
                return NotFound();
            }

            return ItemToDTO(favourite);
        }

        // PUT: api/Favourites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFavourite(string id, Favourite favourite)
        //{
        //    if (id != favourite.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(favourite).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FavouriteExists(id))
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

        // POST: api/Favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavouriteDTO>> PostFavourite(FavouriteDTO favouriteDTO)
        {
            var favourite = new Favourite
            {
                PostId = favouriteDTO.PostId,
                UserId = favouriteDTO.UserId
            };
            _context.Favs.Add(favourite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavouriteExists(favourite.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetFavourite), new { id = favourite.UserId }, ItemToDTO(favourite));
        }

        // DELETE: api/Favourites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(string id)
        {
            var favourite = await _context.Favs.FindAsync(id);
            if (favourite == null)
            {
                return NotFound();
            }

            _context.Favs.Remove(favourite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouriteExists(string id)
        {
            return _context.Favs.Any(e => e.UserId == id);
        }

        private static FavouriteDTO ItemToDTO(Favourite favourite) =>
            new FavouriteDTO
            {
                PostId = favourite.PostId,
                UserId = favourite.UserId
            };


    }
}
