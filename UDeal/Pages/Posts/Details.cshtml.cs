using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly UDeal.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;    

        public DetailsModel(UserManager<User> userManager, UDeal.Data.ApplicationDbContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Post Post { get; set; }
        public bool IsFav { get; set; }
        public Contact PosterContact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            List<Image> images = _context.Images.Where(i => i.PostId == id).ToList();
            ViewData["Images"] = images.Select(i => "/images/" + i.Name).ToList();

            //var image = await _context.Images.Where(x => x.PostId == id).FirstOrDefaultAsync();
            //ViewData["ImagePath"] = image != null ? "/images/" + image.Name : "https://via.placeholder.com/300";
            
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.Course)
                .Include(p => p.Campus)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            PosterContact = await _context.Contacts.Where(c => c.UserId == Post.UserId).FirstOrDefaultAsync();

            if (PosterContact == null)
            {
                PosterContact = new Contact
                {
                    AlternateEmail = User.Identity.Name
                };
            }
            else if (PosterContact.AlternateEmail == null)
            {
                PosterContact.AlternateEmail = User.Identity.Name;
            }

            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                IsFav = _context.UserFavourites.Where(f => f.PostId == id && f.UserId == user.Id).Any();
            }
         

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostRemove(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _context.UserFavourites.Remove(new Favourite
            {
                PostId = id,
                UserId = user.Id
            });
            await _context.SaveChangesAsync();
            return Redirect("/Posts/Favourites");
        }

        public async Task<IActionResult> OnPostFav(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            if (!_context.UserFavourites.Where(f => f.PostId == id && f.UserId == user.Id).Any())
            {
                var fav = new Favourite
                {
                    PostId = id,
                    Post = _context.Posts.Find(id),
                    UserId = user.Id,
                    User = user
                };
                _context.UserFavourites.Add(fav);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Posts/Favourites");
        }
    }
}
