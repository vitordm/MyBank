using FluentValidation;
using MyBank.Domain.Entities.Bank;

namespace MyBank.Domain.Validations.Bank
{
    class BankCustomerValidation : AbstractValidator<BankCustomer>
    {
        public BankCustomerValidation()
        {
            RuleFor(c => c.Document).NotEmpty().WithMessage("Document is mandatory!");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is mandatory!");
            RuleFor(c => c.FullName).NotEmpty().WithMessage("FullName is mandatory!");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Address is mandatory!");

        }
    }
}
