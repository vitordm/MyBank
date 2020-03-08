using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Requests
{
    public class DepositRequest
    {
        public string DepositorName { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }
        public string Digit { get; set; }
        public decimal Amount { get; set; }
    }
}
