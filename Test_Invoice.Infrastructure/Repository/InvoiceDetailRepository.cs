using Test_Invoice.Common.Entities;
using Test_Invoice.Common.interfaces;
using Test_Invoice.Infrastructure.DbContextConfig;

namespace Test_Invoice.Infrastructure.Repository;

public class InvoiceDetailRepository: BaseRepository<InvoiceDetail>, IInvoiceDetail
{
    public InvoiceDetailRepository(TestInvoiceContext context) : base(context)
    {
    }
}