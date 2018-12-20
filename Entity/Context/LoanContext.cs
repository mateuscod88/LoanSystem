using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    public class LoanContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WS-9ZV3LC2;Initial Catalog=Entity.Context.LoanContext;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<>
            modelBuilder.Entity<User>()
                        .HasData(
                            new User { First_Name = "Adam", Last_Name = "Kowalski" },
                            new User { First_Name = "Wojtek", Last_Name = "Wilk" },
                            new User { First_Name = "Anna", Last_Name = "Gesler" }

                        );
        }
    }

}