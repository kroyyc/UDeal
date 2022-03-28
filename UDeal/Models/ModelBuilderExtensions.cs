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

           

        }
    }
}
