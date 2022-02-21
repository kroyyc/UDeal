using System.ComponentModel.DataAnnotations.Schema;

namespace UDeal.Models
{
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City {  get; set; }

        public int SchoolId { get; set; }
        [ForeignKey(nameof(SchoolId))]
        public virtual School School { get; set; }

    }
}
