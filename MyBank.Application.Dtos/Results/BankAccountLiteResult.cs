using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Results
{
    public class BankAccountLiteResult
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }
        public string Digit { get; set; }
        public decimal TotalBalance { get; set; }
        public string Customer { get; set; }
    }
}
