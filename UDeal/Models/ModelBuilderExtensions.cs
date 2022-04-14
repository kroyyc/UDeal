using Microsoft.EntityFrameworkCore;

namespace UDeal.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "University of Calgary", ShortName = "UofC", Domain = "ucalgary.ca" },
                new School { Id = 2, Name = "University of Alberta", ShortName = "UofA", Domain = "ualberta.ca" },
                new School { Id = 3, Name = "Southern Alberta Insitute of Technology", ShortName = "SAIT", Domain = "edu.sait.ca", },
                new School { Id = 4, Name = "Northern Alberta Insitute of Technology", ShortName = "NAIT", Domain = "nait.ca", },
                new School { Id = 5, Name = "University of British Columbia", ShortName = "UBC", Domain = "student.ubc.ca" },
                new School { Id = 6, Name = "Mount Royal University", ShortName = "MRU", Domain = "mtroyal.ca" },
                new School { Id = 7, Name = "University of Saskatchewan", ShortName = "USask", Domain = "mail.usask.ca" },
                new School { Id = 8, Name = "University of Victoria", ShortName = "UVic", Domain = "uvic.ca" }
            );

            modelBuilder.Entity<Campus>().HasData(
                new Campus { Id = 1, Name = "Main", City = "Calgary", SchoolId = 1 },
                new Campus { Id = 2, Name = "Spyhhill", City = "Calgary", SchoolId = 1},
                new Campus { Id = 3, Name = "Downtown", City = "Calgary", SchoolId= 1},
                new Campus { Id = 4, Name = "Quatar", City = "Doha", SchoolId = 1 },

                new Campus { Id = 5, Name = "North", City = "Edmonton", SchoolId = 2 },
                new Campus { Id = 6, Name = "Augustana", City = "Edmonton", SchoolId = 2},
                new Campus { Id = 7, Name = "Saint-Jean", City = "Edmonton", SchoolId = 2 },
                new Campus { Id = 8, Name = "South", City = "Edmonton", SchoolId = 2 },

                new Campus { Id = 9, Name = "Main", City = "Calgary", SchoolId = 3 },
                new Campus { Id = 10, Name = "Main", City = "Edmonton", SchoolId = 4 },

                new Campus { Id = 11, Name = "Vancouver", City = "Vancouver", SchoolId = 5 },
                new Campus { Id = 12, Name = "Okanagan", City = "Kelowna", SchoolId = 5 },

                new Campus { Id = 13, Name = "Main", City = "Calgary", SchoolId = 6 },
                new Campus { Id = 14, Name = "Main", City = "Saskatoon", SchoolId = 7 },
                new Campus { Id = 15, Name = "Main", City = "Victoria", SchoolId = 8 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Textbooks" },
                new Category { Id = 2, Name = "Electronics" },
                new Category { Id = 3, Name = "Furniture" },
                new Category { Id = 4, Name = "Housing" },
                new Category { Id = 5, Name = "Tools"},
                new Category { Id = 6, Name = "Appliances" },
                new Category { Id = 7, Name = "Clothing & Accessories" },
                new Category { Id = 8, Name = "Toys & Games" },
                new Category { Id = 9, Name = "Vehicles" },
                new Category { Id = 10, Name = "Hobbies" },
                new Category { Id = 11, Name = "Home & Garden" },
                new Category { Id = 12, Name = "Books, Movies & Music" }
            );
        }
    }
}
