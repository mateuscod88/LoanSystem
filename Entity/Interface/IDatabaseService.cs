using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Interface
{
    public interface IDatabaseService : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Loan> Loans { get; set; }
        DbSet<Lender> Lenders { get; set; }
        void SaveChanges();
    }
}
