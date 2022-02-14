using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using UDeal.Data;
using UDeal.Models;
using System;
using System.Security.Claims;

namespace UDeal.Data
{
    public class SeedData
    {

        public static void Initialize(System.IServiceProvider serviceProvider)
        {

            using (IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                

                // Lets seed stock posts here
               
            
                context.SaveChanges();

            }

        }


        public static void SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));
                //IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                //roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "Admin"));
                
            }

            if (userManager.FindByEmailAsync("admin@email.local").Result == null)
            {

                User admin = new User
                {
                    UserName = "admin@email.local",
                    Email = "admin@email.local",
                    EmailConfirmed = true,
                };

                IdentityResult result = userManager.CreateAsync(admin, "Admin123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    Console.WriteLine("Failed to seed Admin user");
                }

            }

        }

    }
}
