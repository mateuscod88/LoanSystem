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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}