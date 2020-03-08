using MyBank.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace MyBank.Domain.Entities.Bank
{
    public class BankAccount : IEntity<long>
    {

        public long Id { get; private set; }
        public Guid Uid { get; private set; }
        public BankAccountType Type { get; private set; }
        public string Branch { get; private set; }
        public string Digit { get; private set; }
        public decimal TotalBalance { get; private set; }
        public long BankCustomerId { get; set; }
        public string AuthorizationPass { get; private set; }

        public BankCustomer Customer { get; private set; }
        public IList<BankTransaction> Transactions { get; private set; }
    }
}
