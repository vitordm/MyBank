using MyBank.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities.Bank
{
    public class BankTransaction : IEntity<long>
    {
        public long Id { get; private set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public long BankAccountId { get; private set; }
        public BankAccount Account { get; private set; }

    }
}
