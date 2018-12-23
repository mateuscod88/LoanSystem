using Domain.Lender.Model;
using Domain.User.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Loan.Model
{
    public class LoanModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public UserModel User { get; set; }
        public int LenderId { get; set; }
        public LenderModel Lender { get; set; }
        public float Amount { get; set; }

        public bool IsPaid { get; set; }
    }
}
