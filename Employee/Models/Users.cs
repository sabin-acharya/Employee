﻿using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Users
    {
        
         
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Address { get; set; }

        public int Age { get; set; }
    }
}
