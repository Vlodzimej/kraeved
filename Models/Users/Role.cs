using System;
using System.Collections.Generic;

namespace KraevedAPI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }

        public static readonly Role unknown = new Role() {
            Id = 0,
            Name = "Unknown"
        };
    }
}