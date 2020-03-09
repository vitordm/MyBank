using AutoMapper;
using MyBank.Application.Dtos.Entities.Bank;
using MyBank.Application.Dtos.Results;
using MyBank.Domain.Entities.Bank;

namespace MyBank.Infra.IoC
{
    class MyBankMapperProfile : Profile
    {
        public MyBankMapperProfile()
        {
            CreateMappers();
        }

        void CreateMappers()
        {
            CreateMap<BankCustomer, BankCustomerDto>();
            CreateMap<BankAccount, BankAccountDto>();
            CreateMap<BankTransaction, BankTransactionDto>();

            CreateMap<BankAccount, BankAccountLiteResult>().ForMember(
                dest => dest.Customer, 
                opts => opts.MapFrom(bank => bank.Customer.Name));

            CreateMap<BankTransaction, BankTransactionLiteResult>();
        }
    }
}
