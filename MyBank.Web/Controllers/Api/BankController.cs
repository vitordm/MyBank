using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Application.Dtos.Entities.Bank;
using MyBank.Application.Dtos.Requests;
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
        public async Task<IActionResult> NewCustomer([FromBody] NewCustomerRequest request) => 
            Ok(await bankService.NewCustomer(request));

        [HttpPost("OpenBankAccount")]
        public async Task<IActionResult> OpenBankAccount([FromBody] OpenBankAccountRequest request)
            => Ok(await bankService.OpenBankAccount(request));

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            await bankService.MakeDeposit(request);
            return Ok();
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
            => Ok(await bankService.Withdraw(request));
    }
}