using System.ComponentModel.DataAnnotations;

namespace UDeal.Models
{
    public class Favourite
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; } 
        public Post Post { get; set; }

    }

    public class FavouriteDTO
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
