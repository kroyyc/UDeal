using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UDeal.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Condition Condition { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Category> Categories { get; set; }
      
    }

    public class Selling : Post 
    {
        public int Price { get; set; }
    }

    public class Looking : Post
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }   
    }

    public enum Condition
    {
        New,
        Good,
        Fair
    }
}
