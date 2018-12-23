using Domain.Helpers;
using Domain.User.Model;
using Entity.Context;
using Entity.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.User.Service
{
    public class UserService : IUserService
    {
        private LoanContext _context;
        
        public UserService()
        {
            var service = new ServiceCollection();
            service.AddUserServiceLoanDbContext();
            var provider = service.BuildServiceProvider();
            _context = provider.GetRequiredService<LoanContext>();
        }
        public IQueryable<UserModel> GetAllLoaners()
        {
            return _context.Loans.AsNoTracking().GroupBy(x => x.UserId).Select(x => new UserModel { Id = x.FirstOrDefault().User.Id, First_Name = x.FirstOrDefault().User.First_Name, Last_Name = x.FirstOrDefault().User.Last_Name });
            
        }
        public IQueryable<UserModel> GetAllLenders()
        {
            return _context.Lenders.AsNoTracking().GroupBy(x => x.UserId).Select(x => new UserModel { Id = x.FirstOrDefault().User.Id, First_Name = x.FirstOrDefault().User.First_Name, Last_Name = x.FirstOrDefault().User.Last_Name });
        }
        public IQueryable<UserModelWithOperationType> GetAllLendersAndLoaners()
        {
            var loaners = _context.Loans.AsNoTracking().Select(x => new UserModelWithOperationType { Id = x.User.Id, First_Name = x.User.First_Name, Last_Name = x.User.Last_Name,OperationType = "Loan" });
            var lenders = _context.Lenders.AsNoTracking().Select(x => new UserModelWithOperationType { Id = x.User.Id, First_Name = x.User.First_Name, Last_Name = x.User.Last_Name,OperationType = "Lender" });
            return loaners.Concat(lenders); 
        }

        public void AddUser(UserModel user)
        {
            var userEntity = new Entity.Entity.User();
            userEntity.First_Name = user.First_Name;
            userEntity.Last_Name = user.Last_Name;
            _context.Users.Add(userEntity);
            _context.SaveChanges();
        }
    }
}
