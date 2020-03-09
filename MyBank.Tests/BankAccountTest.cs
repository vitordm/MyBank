using MyBank.Domain.Entities.Bank;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyBank.Tests
{
    public class BankAccountTest
    {
        [Theory]
        [InlineData("0001", "0001", "1", "1234")]
        [InlineData("0001", "0002", "1", "1234")]
        public void OpenAccountTest(string branch, string account, string digit, string password)
        {
            var customer = new BankCustomer("00000000000", "John", "Doe", "Road Street");
            var bankAccount = new BankAccount(branch, account, digit, password, customer);

            Assert.Equal(0, bankAccount.TotalBalance);
            Assert.Equal(1, bankAccount.Transactions.Count);
        }
    }
}
