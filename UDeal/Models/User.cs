using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UDeal.Models
{
    public class User : IdentityUser
    {
        public int? SchoolId { get; set; }  // Optional: some users like admin may not have a school. New users must however
        public School School { get; set; }

        public int? CampusId { get; set; }
        public Campus Campus { get; set; }

    }
}
