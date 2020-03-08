using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.Domain.Entities.Bank;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.Data.Configurations
{
    public class BankCustomerConfiguration : IEntityTypeConfiguration<BankCustomer>
    {
        public void Configure(EntityTypeBuilder<BankCustomer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.FullName).IsRequired();
            builder.Property(b => b.Address).IsRequired();
            builder.Property(b => b.Document).IsRequired();
            builder.HasMany(c => c.Accounts).WithOne(b => b.Customer);
        }
    }
}
