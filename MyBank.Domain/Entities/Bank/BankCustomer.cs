using MyBank.Domain.Contracts;
using System.Collections.Generic;

namespace MyBank.Domain.Entities.Bank
{
    public class BankCustomer : IEntity<long>
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public string Address { get; private set; }
        public IList<BankAccount> Accounts { get; set; }

    }
}
