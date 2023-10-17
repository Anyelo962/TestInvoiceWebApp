using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Invoice.Common.Entities;

namespace Test_Invoice.Infrastructure.DbContext.Configuration;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Customer");

        builder.Property(e => e.Adress).HasMaxLength(120);
        builder.Property(e => e.CustName).HasMaxLength(70);
        builder.Property(e => e.CustomerTypeId).HasDefaultValueSql("((1))");
        builder.Property(e => e.Status)
            .IsRequired()
            .HasDefaultValueSql("((1))");

        builder.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
            .HasForeignKey(d => d.CustomerTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customers_CustomerTypes");
    }
}