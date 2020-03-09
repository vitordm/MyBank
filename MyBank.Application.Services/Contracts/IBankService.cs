using MyBank.Application.Dtos.Entities.Bank;
using MyBank.Application.Dtos.Requests;
using MyBank.Application.Dtos.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBank.Application.Services.Contracts
{
    public interface IBankService : IService
    {
        Task<BankCustomerDto> NewCustomer(NewCustomerRequest request);
        Task<BankAccountDto> OpenBankAccount(OpenBankAccountRequest request);
        Task MakeDeposit(DepositRequest request);
        Task<BankTransactionDto> Withdraw(WithdrawRequest request);
        Task<BankAccountLiteResult> GetAccount(GetAccountRequest request);
        Task<IList<BankTransactionLiteResult>> GetTransactionsFromAccountUid(Guid accountUid);
        Task<BankAccountLiteResult> GetAccountByUid(Guid accountUid);
    }
}
