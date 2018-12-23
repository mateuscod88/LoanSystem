using Domain.User.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public class UserComparer : IEqualityComparer<UserModel>
    {
        public bool Equals(UserModel x, UserModel y)
        {
            if (x.Id == y.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(UserModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
