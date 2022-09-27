using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Users
    {
        public Users()
        {
        }
        [Key]
        public int UserId { get; set; }

        // BASIC DATA FIELD
        public string FirstName { get; set; }
        public string LastName { get; set; }


        // AUTHENTICATION DATA FIELD
        public string Email { get; set; }
        public string Password { get; set; }


        // ROLE DATA FIELD
        public string Role { get; set; } = "Member";
    }
}
