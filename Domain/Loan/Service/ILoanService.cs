using Domain.Loan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Loan.Service
{
    public interface ILoanService
    {
        IQueryable<LoanModel> GetLoanByUserId(int userId);
        void PayBackLoanById(int loanId);
        LoanModel AddLoan(LoanModel loan);
        LoanModel GetLoanById(int id);

    }
}
