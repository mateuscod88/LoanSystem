using System.Collections.Generic;

namespace Entity
{
    public class FinanseOperation
    {
        public long FinanseOperationId { get; set; }
        public FinanseOperationType OperationType { get; set; }
        public User Owner { get; set; }
        public long Amount { get; set; }

    }
}