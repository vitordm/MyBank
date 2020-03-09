using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Results
{
    public class BankTransactionLiteResult
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
