using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Invoice.Common.Entities;

namespace Test_Invoice.Infrastructure.DbContext.Configuration;

public class InvoiceConfiguration:IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice");

        builder.Property(e => e.SubTotal).HasColumnType("money");
        builder.Property(e => e.Total).HasColumnType("money");
        builder.Property(e => e.TotalItbis).HasColumnType("money");

        builder.HasOne(d => d.Customer).WithMany(p => p.Invoices)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK_Invoice_Customers");
    }
}