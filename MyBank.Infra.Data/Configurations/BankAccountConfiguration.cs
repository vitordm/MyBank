using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBank.Domain.Entities.Bank;
using System;
using System.Collections.Generic;
using System.Text;

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
            builder.HasOne(b => b.Customer).WithMany(c => c.Accounts);
            builder.Property(b => b.Type).HasConversion(new EnumToStringConverter<BankAccountType>());
        }
    }
}
