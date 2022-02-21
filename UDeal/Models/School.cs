using System.Collections.Generic;

namespace UDeal.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Domain { get; set; }

        //public virtual ICollection<User> Students { get; set; }
        //public virtual ICollection<Campus> Campuses { get; set; }
    }
}
