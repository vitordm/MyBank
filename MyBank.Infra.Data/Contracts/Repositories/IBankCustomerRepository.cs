using MyBank.Domain.Entities.Bank;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Contracts.Repositories
{
    public interface IBankCustomerRepository : IGenericRepository<BankCustomer, long>
    {
        Task<BankCustomer> FindCustomerByDocumentAsync(string document);
    }
}
