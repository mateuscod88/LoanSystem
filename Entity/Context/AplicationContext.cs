using Entity.Entity;
using Entity.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entity.Seed;

namespace Entity.Context
{
    public class AplicationContext : IdentityDbContext<AplicationUser>
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {

        }
        public AplicationContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WS-9ZV3LC2;Database=AplicationDb;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}