using System.Collections.Generic;

namespace UDeal.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Condition Condition { get; set; }

        public int? Price { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public PostType Type { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Condition Condition { get; set; }
        public int? Price { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public PostType Type { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
    }

    public enum PostType
    {
        Selling, 
        Looking
    }

    public enum Condition
    {
        New,
        Good,
        Fair
    }
}
