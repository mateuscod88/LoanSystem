using Domain.Helpers;
using Domain.Loan.Model;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Loan.Service
{
    public class LoanService : ILoanService
    {
        private LoanContext _context;
        public LoanService()
        {
            var service = new ServiceCollection();
            service.AddUserServiceLoanDbContext();
            var provider = service.BuildServiceProvider();
            _context = provider.GetRequiredService<LoanContext>();
        }
        public IQueryable<LoanModel> GetLoanByUserId(int userId)
        {
           return  _context.Loans.AsNoTracking().Where(x => x.UserId == userId).Select(x => new LoanModel { Id = x.Id, Amount = x.Amount });
        }
        public void PayBackLoanById(int loanId)
        {

        }

    }
}
