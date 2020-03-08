using MyBank.Domain.Entities.Bank;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.Data.Repositories.Bank
{
    public class BankAccountRepository : GenericRepository<BankAccount, long>, IBankAccountRepository
    {
        public BankAccountRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
