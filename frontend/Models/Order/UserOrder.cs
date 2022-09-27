using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class UserOrder
    {
        public int TransactionId { get; set; }

        // BASIC DATA FIELD 
        public long MemberId { get; set; }
        public string ProductName { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Quantities { get; set; }

        // ADVANCED
        public Users User { get; set; }
        public Order Order { get; set; }

        // BASIC DATA FIELD
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
