using MyBank.Domain.Contracts;
using MyBank.Domain.Validations.Bank;
using MyBank.Infra.Helpers.Exceptions;
using System.Collections.Generic;

namespace MyBank.Domain.Entities.Bank
{
    public class BankCustomer : IEntity<long>
    {
        public long Id { get; private set; }
        public string Document { get; set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public string Address { get; private set; }
        public IList<BankAccount> Accounts { get; set; } = new List<BankAccount>();

        protected BankCustomer()
        {

        }
        
        public BankCustomer(string document, string name, string fullName, string address)
        {
            Document = document;
            Name = name;
            FullName = fullName;
            Address = address;

            var validator = (new BankCustomerValidation()).Validate(this);
            if (!validator.IsValid)
            {
                throw new ApplicationException(validator.Errors);
            }

        }
    }
}
