using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.Domain.Entities.Bank;
using System;

namespace MyBank.Infra.Data.Configurations
{
    public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreateDate);
            builder.Property(b => b.Description).IsRequired();
            builder.HasOne(b => b.Account).WithMany(a => a.Transactions);

            builder.HasData(new
            {
                Id = 1L,
                CreateDate = DateTime.Now,
                Description = "Initital Transaction",
                BankAccountId = 1L,
                Amount = default(decimal)
            });
        }
    }
}
