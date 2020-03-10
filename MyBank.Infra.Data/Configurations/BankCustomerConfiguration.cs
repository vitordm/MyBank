using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.Domain.Entities.Bank;

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

            //builder.HasData(new BankCustomer("000000000000", "John", "Snow", "The North"));
            builder.HasData(new
            {
                Id = 1L,
                Document = "00000000000",
                Name = "John",
                FullName = "Snow",
                Address = "The North"
            });
        }
    }
}
