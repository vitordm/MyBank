using Microsoft.EntityFrameworkCore;
using MyBank.Domain.Entities.Bank;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repositories.Bank
{
    public class BankCustomerRepository : GenericRepository<BankCustomer, long>, IBankCustomerRepository
    {
        public BankCustomerRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<BankCustomer> FindCustomerByDocumentAsync(string document)
        {
            return await UnitOfWork.Set<BankCustomer>()
                .Where(c => c.Document == document)
                .FirstOrDefaultAsync();
        }
    }
}
