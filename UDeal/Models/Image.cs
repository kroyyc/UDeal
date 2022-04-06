namespace UDeal.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }

    public class ImageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }

    }
}
