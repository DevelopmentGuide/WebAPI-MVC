using System;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Users> User { get; set; }
        public DbSet<ContactUs> ContactMsg { get; set; }

        // GIVING PREDIFINED DATA TO DATABASE 
        // CREATING ADMIN USER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CREATING SAMPLE USER
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    Email = "admin@localhost",
                    Password = "Passcode1",
                    Role = Roles.Admin
                }
                );

            // ADDING DEFAULT CONTACTUS DATA
            modelBuilder.Entity<ContactUs>().HasData(
                new ContactUs
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Name = "sample",
                    Email = "sample@localhost",
                    Message = "Hello, I am sample user. I am facing some issues with the website. Please help me out."
                });
        }
    }
}
