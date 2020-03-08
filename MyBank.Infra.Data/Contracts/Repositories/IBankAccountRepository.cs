using MyBank.Domain.Entities.Bank;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.Data.Contracts.Repositories
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount, long>
    {
    }
}
