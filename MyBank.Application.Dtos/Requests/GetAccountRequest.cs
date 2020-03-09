using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Requests
{
    public class GetAccountRequest
    {
        public string Branch { get; set; }
        public string Account { get; set; }
        public string Digit { get; set; }
        public string AuthorizationPass { get; set; }
    }
}
