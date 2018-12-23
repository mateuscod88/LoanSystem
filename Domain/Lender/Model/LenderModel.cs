using Domain.User.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Lender.Model
{
    public class LenderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
