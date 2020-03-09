using Microsoft.EntityFrameworkCore;
using MyBank.Domain.Entities.Bank;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repositories.Bank
{
    public class BankAccountRepository : GenericRepository<BankAccount, long>, IBankAccountRepository
    {
        public BankAccountRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<BankAccount> FindAccountAsync(string branch, string account, string digit)
        {
            return await UnitOfWork.Set<BankAccount>()
                .Include(b => b.Customer)
                .Include(b => b.Transactions)
                .Where(b => b.Branch == branch && b.Account == account && b.Digit == digit)
                .FirstOrDefaultAsync();
        }

        public async Task<BankAccount> FindAccountAsync(string branch, string account, string digit, string authorizationPass)
        {
            return await UnitOfWork.Set<BankAccount>()
                .Include(b => b.Customer)
                .Include(b => b.Transactions)
                .Where(b => b.Branch == branch && b.Account == account && b.Digit == digit && b.AuthorizationPass == authorizationPass)
                .FirstOrDefaultAsync();
        }

        public async Task<BankAccount> FindAccountByUidAsync(Guid accountUid)
        {
            return await UnitOfWork.Set<BankAccount>()
                .Include(b => b.Customer)
                .Where(b => b.Uid == accountUid)
                .FirstOrDefaultAsync();
        }
    }
}
