using MyBank.Domain.Entities.Bank;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Contracts.Repositories
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount, long>
    {
        Task<BankAccount> FindAccountAsync(string branch, string account, string digit);
        Task<BankAccount> FindAccountAsync(string branch, string account, string digit, string authorizationPass);
        Task<BankAccount> FindAccountByUidAsync(Guid accountUid);
    }
}
