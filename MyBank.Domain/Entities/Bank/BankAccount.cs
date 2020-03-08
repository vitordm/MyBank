using MyBank.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBank.Domain.Entities.Bank
{
    public class BankAccount : IEntity<long>
    {

        public long Id { get; private set; }
        public Guid Uid { get; private set; }
        public DateTime CreateDate { get; private set; }

        public BankAccountType Type { get; private set; }
        public string Branch { get; private set; }
        public string Account { get; private set; }
        public string Digit { get; private set; }
        public decimal TotalBalance { get; private set; }
        public long BankCustomerId { get; private set; }
        public string AuthorizationPass { get; private set; }

        public bool IsMainAccount { get; private set; }

        public BankCustomer Customer { get; private set; }
        public IList<BankTransaction> Transactions { get; private set; } = new List<BankTransaction>();

        protected BankAccount()
        {

        }

        public BankAccount(string branch, string account,  string digit, string authorizationPass, BankCustomer customer)
        {
            Uid = Guid.NewGuid();
            Branch = branch;
            Account = account;
            Digit = digit;
            AuthorizationPass = authorizationPass;
            BankCustomerId = customer.Id;
            Customer = customer;
            Customer.Accounts.Add(this);
            AddDeposit(new BankTransaction("OPEN ACCOUNT", 0, this));
        }


        public void AddDeposit(BankTransaction transaction)
        {
            if (transaction.Amount < 0)
                throw new ApplicationException("The amount value is invalid. Any deposit must be greater than ZERO!");

            Transactions.Add(transaction);
            CalculateBalance();
        }

        public void AddWithdraw(BankTransaction transaction)
        {
            if (transaction.Amount >= 0)
                throw new ApplicationException("The amount value is invalid. Any withdraw must be less than zero!");


            var totalBalance = TotalBalance - (transaction.Amount * -1);

            if (totalBalance < 0)
                throw new ApplicationException($"The amount value is invalid. The amount must be less or equal to balance. {transaction.Amount} > {TotalBalance}");

            Transactions.Add(transaction);
            CalculateBalance();
        }

        public void CalculateBalance()
        {
            TotalBalance = Transactions.Sum(t => t.Amount);
        }

        
    }
}
