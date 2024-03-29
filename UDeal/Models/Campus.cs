﻿
using System.Collections.Generic;

namespace UDeal.Models
{
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City {  get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<User> Users { get; set; }

    }

    public class CampusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int SchoolId { get; set; }
    }
}
