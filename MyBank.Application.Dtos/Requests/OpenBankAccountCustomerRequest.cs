using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Requests
{
    public class OpenBankAccountCustomerRequest
    {
        public string Document { get; set; }
        public string Name { get; set; }
    }
}
