using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Invoice.Common.Entities;

namespace Test_Invoice.Infrastructure.DbContext.Configuration;

public class CustomerTypeConfiguration: IEntityTypeConfiguration<CustomerType>
{
    public void Configure(EntityTypeBuilder<CustomerType> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_CustomerType");

        builder.Property(e => e.Description).HasMaxLength(70);
    }
}