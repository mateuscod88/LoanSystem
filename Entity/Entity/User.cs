using System.Collections.Generic;

namespace Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public ICollection<FinanseOperation> FinanseOperations { get; set; }

    }
}