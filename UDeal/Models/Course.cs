using System.Collections.Generic;

namespace UDeal.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
    }
}
