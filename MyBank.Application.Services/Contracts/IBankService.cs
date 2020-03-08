using MyBank.Application.Dtos.Entities.Bank;
using MyBank.Application.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application.Services.Contracts
{
    public interface IBankService : IService
    {
        Task<BankCustomerDto> NewCustomer(NewCustomerRequest request);
        Task<BankAccountDto> OpenBankAccount(OpenBankAccountRequest request);
        Task MakeDeposit(DepositRequest request);
        Task<BankTransactionDto> Withdraw(WithdrawRequest request);
    }
}
