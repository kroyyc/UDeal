using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDeal.Data;
using UDeal.Models;

namespace UDeal.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }
        public string SchoolName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [EmailAddress]
            [Display(Name = "Alternate Email")]
            public string AlternateEmail { get; set; }
            public string Address { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            if (user.SchoolId != null)
            {
                SchoolName = _context.Schools.Find(user.SchoolId).Name;
            }
            else
            {
                SchoolName = "N/A";
            }

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                
            };

            var contactInfo = _context.Contacts.Where(c => c.UserId == user.Id).FirstOrDefault();
            if (contactInfo != null)
            {
                Input.Address = contactInfo.Address;
                Input.AlternateEmail = contactInfo.AlternateEmail;
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var contact = _context.Contacts.Where(c => c.UserId == user.Id).FirstOrDefault();
            if (contact != null)
            {
                contact.PhoneNumber = Input.PhoneNumber;
                contact.AlternateEmail = Input.AlternateEmail;
                contact.Address = Input.Address;
                
            }
            else
            {
                contact = new Contact
                {
                    AlternateEmail = Input.AlternateEmail,
                    Address = Input.Address,
                    PhoneNumber = Input.PhoneNumber,
                    User = user,
                    UserId = user.Id
                }; 
                _context.Contacts.Add(contact);
            }
            await _context.SaveChangesAsync();

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
