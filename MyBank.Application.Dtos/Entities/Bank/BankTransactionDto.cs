using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Entities.Bank
{
    public class BankTransactionDto
    {
        public class BankTransaction
        {
            public long Id { get; set; }
            public DateTime CreateDate { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public long BankAccountId { get; set; }
            public BankAccountDto Account { get; set; }

        }
    }
}
