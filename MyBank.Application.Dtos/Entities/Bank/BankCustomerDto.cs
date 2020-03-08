using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Entities.Bank
{
    public class BankCustomerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public IList<BankAccountDto> Accounts { get; set; }
    }
}
