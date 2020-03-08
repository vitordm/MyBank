using MyBank.Domain.Contracts;
using System;

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

        protected BankTransaction()
        {

        }

        public BankTransaction(string description, decimal amount, BankAccount account)
        {
            CreateDate = DateTime.Now;
            Description = description;
            Amount = amount;
            Account = account;
            BankAccountId = account.Id;
        }
    }
}
