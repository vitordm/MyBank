using AutoMapper;
using MyBank.Application.Dtos.Entities.Bank;
using MyBank.Application.Dtos.Requests;
using MyBank.Application.Dtos.Results;
using MyBank.Application.Services.Contracts;
using MyBank.Domain.Entities.Bank;
using MyBank.Infra.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application.Services.Services
{
    public class BankService : IBankService
    {
        private readonly IBankAccountRepository bankAccountRepository;
        private readonly IBankCustomerRepository bankCustomerRepository;
        private readonly IBankTransactionRepository bankTransactionRepository;
        private readonly IMapper mapper;

        public BankService(IBankAccountRepository bankAccountRepository,
                           IBankCustomerRepository bankCustomerRepository,
                           IBankTransactionRepository bankTransactionRepository,
                           IMapper mapper)
        {
            this.bankAccountRepository = bankAccountRepository;
            this.bankCustomerRepository = bankCustomerRepository;
            this.bankTransactionRepository = bankTransactionRepository;
            this.mapper = mapper;
        }

        public async Task<BankCustomerDto> NewCustomer(NewCustomerRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Document))
            {
                throw new InvalidOperationException("Document is Empty!");
            }

            var customer = await bankCustomerRepository.FindCustomerByDocumentAsync(request.Document);

            if (customer != null)
            {
                throw new InvalidOperationException("Customer is already registered!");
            }

            customer = new BankCustomer(request.Document, request.Name, $"{request.Name} {request.LastName}".Trim(), request.Address);

            await bankCustomerRepository.InsertAsync(customer);

            return mapper.Map<BankCustomerDto>(customer);
        }

        public async Task<BankAccountDto> OpenBankAccount(OpenBankAccountRequest request)
        {
            var convertedType = Enum.TryParse(request.Type, out BankAccountType type);

            if (!convertedType)
                throw new InvalidOperationException("Type of Account is Invalid!");

            var customer = await bankCustomerRepository.FindCustomerByDocumentAsync(request.Customer.Document);

            if (customer is null)
                throw new InvalidOperationException("Customer is invalid!");

            var account = await bankAccountRepository.FindAccountAsync(request.Branch, request.Account, request.Digit);
            if (account != null)
                throw new InvalidOperationException("Account is already registered");

            account = new BankAccount(request.Branch, request.Account, request.Digit, request.AuthorizationPass, customer);

            await bankAccountRepository.InsertAsync(account);

            return mapper.Map<BankAccountDto>(account);
        }

        public async Task MakeDeposit(DepositRequest request)
        {
            var account = await bankAccountRepository.FindAccountAsync(request.Branch, request.Account, request.Digit);

            if (account is null)
                throw new InvalidOperationException("Account is invalid!");

            if (string.IsNullOrEmpty(request.DepositorName))
                request.DepositorName = "NOT DECLARED";

            var description = $"DEPOSIT - FROM {request.DepositorName}";

            var transaction = new BankTransaction(description, request.Amount, account);

            account.AddDeposit(transaction);

            await bankAccountRepository.UpdateAsync(account);
        }

        public async Task<BankTransactionDto> Withdraw(WithdrawRequest request)
        {
            var account = await bankAccountRepository.FindAccountAsync(request.Branch, request.Account, request.Digit);

            if (account is null)
                throw new InvalidOperationException("Account is invalid!");

            var description = $"WITHDRAW";

            var transaction = new BankTransaction(description, request.Amount, account);

            account.AddWithdraw(transaction);

            await bankAccountRepository.UpdateAsync(account);

            return mapper.Map<BankTransactionDto>(transaction);
        }

        public async Task<BankAccountLiteResult> GetAccount(GetAccountRequest request)
        {
            var bankAccount = await bankAccountRepository.FindAccountAsync(
                request.Branch, request.Account, request.Digit, request.AuthorizationPass);
            return mapper.Map<BankAccountLiteResult>(bankAccount);
        }

        public async Task<IList<BankTransactionLiteResult>> GetTransactionsFromAccountUid(Guid accountUid)
        {
            var bankAccount = await bankAccountRepository.FindAccountByUidAsync(accountUid);
            if (bankAccount is null)
                throw new InvalidOperationException("Account is invalid!");

            return mapper.Map<IList<BankTransactionLiteResult>>(await bankTransactionRepository.GetTransactionsOf(bankAccount));
        }

        public async Task<BankAccountLiteResult> GetAccountByUid(Guid accountUid)
        {
            var account = await bankAccountRepository.FindAccountByUidAsync(accountUid);
            return mapper.Map<BankAccountLiteResult>(account);
        }
    }
}
