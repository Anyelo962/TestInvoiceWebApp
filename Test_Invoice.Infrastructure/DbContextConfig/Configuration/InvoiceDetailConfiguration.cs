using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Invoice.Common.Entities;

namespace Test_Invoice.Infrastructure.DbContext.Configuration;

public class InvoiceDetailConfiguration: IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.ToTable("InvoiceDetail");

        builder.Property(e => e.Price).HasColumnType("money");
        builder.Property(e => e.SubTotal).HasColumnType("money");
        builder.Property(e => e.Total).HasColumnType("money");
        builder.Property(e => e.TotalItbis).HasColumnType("money");

        builder.HasOne(d => d.Customer).WithMany(p => p.InvoiceDetails)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK_InvoiceDetail_Invoice");
    }
}