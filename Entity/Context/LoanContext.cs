using System.Collections.Generic;
using Entity.Entity;
using Entity.Interface;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    public class LoanContext : DbContext, IDatabaseService
    {
        public LoanContext(DbContextOptions options) : base(options)
        {

        }
        public LoanContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Lender> Lenders { get; set; }
        public void SaveChanges()
        {
            this.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WS-9ZV3LC2;Database=LoanDb;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasData(
                            new User { Id = 1, First_Name = "Adam", Last_Name = "Kowalski" },
                            new User { Id = 2, First_Name = "Wojtek", Last_Name = "Wilk" },
                            new User { Id = 3, First_Name = "Anna", Last_Name = "Gesler" },
                            new User { Id = 4, First_Name = "Anna", Last_Name = "Malynowska" },
                            new User { Id = 5, First_Name = "Anna", Last_Name = "Szczeciniak" }
                        );
            modelBuilder.Entity<Lender>()
                        .HasData(
                            new Lender { Id = 1, UserId = 1 },
                            new Lender { Id = 2, UserId = 2 },
                            new Lender { Id = 3, UserId = 3 },
                            new Lender { Id = 4, UserId = 4 }
                        );
            modelBuilder.Entity<Loan>()
                        .HasData(
                            new Loan { Id = 1, IsPaid = false, Amount = 5000, UserId = 3, LenderId = 1 },
                            new Loan { Id = 2, IsPaid = false, Amount = 300, UserId = 4, LenderId = 3 },
                            new Loan { Id = 4, IsPaid = false, Amount = 300, UserId = 4, LenderId = 3 },
                            new Loan { Id = 3, IsPaid = false, Amount = 2300, UserId = 1, LenderId = 2 }

                        );
        }
    }

}