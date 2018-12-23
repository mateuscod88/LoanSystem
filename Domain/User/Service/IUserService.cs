using Domain.User.Model;
using Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.User.Service
{
    public interface IUserService
    {
        IQueryable<UserModel> GetAllLoaners();
        IQueryable<UserModel> GetAllLenders();
        IQueryable<UserModelWithOperationType> GetAllLendersAndLoaners();

        void AddUser(UserModel user);
    }
}
