using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBank.Domain.Entities.Bank;
using System;

namespace MyBank.Infra.Data.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Branch).IsRequired();
            builder.Property(b => b.Account).IsRequired();
            builder.Property(b => b.Digit).IsRequired();
            builder.Property(b => b.AuthorizationPass).IsRequired();
            builder.Property(b => b.Profitable).HasDefaultValue(true);
            builder.HasOne(b => b.Customer).WithMany(c => c.Accounts);
            builder.Property(b => b.Type).HasConversion(new EnumToStringConverter<BankAccountType>());

            builder.HasData(new
            {
                Id = 1L,
                Uid = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Type = BankAccountType.CURRENT_ACCOUNT,
                Branch = "0001",
                Account = "0010",
                Digit = "1",
                BankCustomerId = 1L,
                AuthorizationPass = "1234",
                Profitable = true,
                IsMainAccount = true,
                TotalBalance = default(decimal)
            }); ;
        }
    }
}
