using System.Collections.Generic;

namespace UDeal.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public List<User> Students { get; set; }

    }
}
