using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Application.Dtos.Requests
{
    public class NewCustomerRequest
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
