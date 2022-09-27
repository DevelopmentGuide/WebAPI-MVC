using System;
namespace Frontend.Models
{
    public class ContactUs
    {
        public ContactUs()
        {
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
