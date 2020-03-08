using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Requests
{
    public class OpenBankAccountRequest
    {
        public OpenBankAccountCustomerRequest Customer { get; set; }
        public string Type { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }
        public string Digit { get; set; }
        public string AuthorizationPass { get; set; }
        
    }
}
