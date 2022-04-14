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
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> Search(string title)
        {

            IQueryable<Post> posts = _context.Posts;

            if (!string.IsNullOrEmpty(title))
            {
                posts = posts.Where(x => x.Title.Contains(title));
            }

            return await posts
                .Select(p => ItemToDTO(p))
                .ToListAsync();
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            return await _context.Posts
                .Select(p => ItemToDTO(p))
                .ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return ItemToDTO(post);
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDTO postDTO)
        {
            if (id != postDTO.Id)
            {
                return BadRequest();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.Quantity = postDTO.Quantity;
            post.Condition = postDTO.Condition;
            post.Description = postDTO.Description;
            post.Title = postDTO.Title;
            post.Category = _context.Categories.Find(postDTO.CategoryId);
            post.Price = postDTO.Price;
            post.MaxPrice = postDTO.MaxPrice;
            post.MinPrice = postDTO.MinPrice;
            post.Type = postDTO.Type;
            post.Course = _context.Courses.Find(postDTO.CourseId);
          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostDTO>> PostPost(PostDTO postDTO)
        {
            var post = new Post
            {
                Title = postDTO.Title,
                Description = postDTO.Description,
                Quantity = postDTO.Quantity,
                Condition = postDTO.Condition,
                Price = postDTO.Price,
                Category = _context.Categories.Find(postDTO.CategoryId),
                MaxPrice = postDTO.MaxPrice,
                MinPrice = postDTO.MinPrice,
                UserId = postDTO.UserId,
                Type = postDTO.Type,
                Course = _context.Courses.Find(postDTO.CourseId),
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, ItemToDTO(post));
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }

        private static PostDTO ItemToDTO(Post post) =>
            new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                Quantity = post.Quantity,
                Condition = post.Condition,
                UserId = post.UserId,
                CategoryId = post.CategoryId,
                Price = post.Price,
                MaxPrice = post.MaxPrice,
                MinPrice = post.MinPrice,
                Type = post.Type,
                CourseId = post.CourseId,
            };
    }
}
