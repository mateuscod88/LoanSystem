using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Entity
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int LenderId { get; set; }
        public Lender Lender { get; set; }
        public float Amount { get; set; }

        public bool IsPaid { get; set; }
    }
}
