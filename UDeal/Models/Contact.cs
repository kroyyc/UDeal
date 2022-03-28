namespace UDeal.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string AlternateEmail { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

    public class ContactDTO 
    {
        public int Id { get; set; }
        public string AlternateEmail { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
    }

}
