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
            return _context.Loans.AsNoTracking().Where(x => x.UserId == userId).Select(x => new LoanModel { Id = x.Id, Amount = x.Amount, IsPaid = x.IsPaid, UserId = x.UserId, LenderId = x.LenderId });
        }
        public void PayBackLoanById(int loanId)
        {
            var loan = _context.Loans.FirstOrDefault(x => x.Id == loanId);
            if (loan != null)
            {
                loan.IsPaid = true;
                _context.Update(loan);
                _context.SaveChanges();
            }

        }
        public LoanModel AddLoan(LoanModel loan)
        {
            var loanEntity = new Entity.Entity.Loan();
            loanEntity.LenderId = loan.LenderId;
            loanEntity.UserId = loan.UserId;
            loanEntity.Amount = loan.Amount;
            loanEntity.IsPaid = loan.IsPaid;
            _context.Loans.Add(loanEntity);
            _context.SaveChanges();

            return new LoanModel
            {
                Id = loanEntity.Id,
                Amount = loanEntity.Amount,
                IsPaid = loanEntity.IsPaid,
                LenderId = loanEntity.LenderId,
                UserId = loanEntity.UserId,
            };

        }
        public LoanModel GetLoanById(int id)
        {
            return _context.Loans.Select(x => new LoanModel { Id = x.Id, Amount = x.Amount, IsPaid = x.IsPaid, LenderId = x.LenderId, UserId = x.UserId }).FirstOrDefault(y => y.Id == id);
        }


    }
}
