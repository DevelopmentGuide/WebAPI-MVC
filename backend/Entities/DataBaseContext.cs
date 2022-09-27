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
        }
    }
}
