using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Entities.Bank
{
    public class BankAccountDto
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Type { get; set; }
        public string Branch { get; set; }
        public string Digit { get; set; }
        public decimal TotalBalance { get; set; }
        public long BankCustomerId { get; set; }
        public string AuthorizationPass { get; set; }

        public BankCustomerDto Customer { get; set; }
        public IList<BankTransactionDto> Transactions { get; set; }
    }
}
