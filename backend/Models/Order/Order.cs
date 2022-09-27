using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Order
    {
        [Key]
        public int TransactionId { get; set; }


        // BASIC DATA FIELD 
        public long MemberId { get; set; }
        public string ProductName { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Quantities { get; set; }


        // ADVANCED
        public Users User { get; set; }
        public int UserId { get; set; }

    }
}
