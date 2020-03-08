using AutoMapper;
using MyBank.Application.Dtos.Entities.Bank;
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
        }
    }
}
