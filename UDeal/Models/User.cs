using Microsoft.AspNetCore.Identity;

namespace UDeal.Models
{
    public class User : IdentityUser
    {
        public int? SchoolId { get; set; }  // Optional: some users like admin may not have a school. New users must however
        //public virtual School School { get; set; }

        public int? CampusId { get; set; }
        //public virtual Campus Campus { get; set; }

    }
}
