using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Application.Dtos.Entities.Bank;
using MyBank.Application.Dtos.Requests;
using MyBank.Application.Dtos.Results;
using MyBank.Application.Services.Contracts;

namespace MyBank.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService bankService;
        public BankController(IBankService bankService)
        {
            this.bankService = bankService;
        }

        [HttpPost("NewCustomer")]
        [ProducesResponseType(typeof(BankCustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> NewCustomer([FromBody] NewCustomerRequest request) => 
            Ok(await bankService.NewCustomer(request));

        [HttpPost("OpenBankAccount")]
        [ProducesResponseType(typeof(BankAccountDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> OpenBankAccount([FromBody] OpenBankAccountRequest request)
            => Ok(await bankService.OpenBankAccount(request));

        [HttpPost("Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            await bankService.MakeDeposit(request);
            return Ok();
        }

        [HttpPost("Withdraw")]
        [ProducesResponseType(typeof(BankTransactionDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
            => Ok(await bankService.Withdraw(request));

        [HttpPost("Account")]
        [ProducesResponseType(typeof(BankAccountLiteResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Account([FromBody] GetAccountRequest request)
        {
            var conta = await bankService.GetAccount(request);
            if (conta is null)
                return NotFound();
            return Ok(conta);
        }

        [HttpGet("Account")]
        [ProducesResponseType(typeof(   BankAccountLiteResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Account([FromQuery] Guid accountUid)
        {
            var conta = await bankService.GetAccountByUid(accountUid);
            if (conta is null)
                return NotFound();
            return Ok(conta);
        }

        [HttpGet("AccountTransactions")]
        [ProducesResponseType(typeof(IList<BankTransactionLiteResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AccountTransactions([FromQuery] Guid accountUid)
            => Ok(await bankService.GetTransactionsFromAccountUid(accountUid));
    }
}