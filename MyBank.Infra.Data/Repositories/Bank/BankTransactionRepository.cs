using Microsoft.EntityFrameworkCore;
using MyBank.Domain.Entities.Bank;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repositories.Bank
{
    public class BankTransactionRepository : GenericRepository<BankTransaction, long>, IBankTransactionRepository
    {
        public BankTransactionRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<BankTransaction>> GetTransactionsOf(BankAccount bankAccount)
        {
            return await  UnitOfWork.Set<BankTransaction>()
                .Where(t => t.BankAccountId == bankAccount.Id)
                .OrderByDescending(t => t.CreateDate)
                .ToListAsync();
        }
    }
}
