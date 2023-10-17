using Test_Invoice.Common.Entities;
using Test_Invoice.Common.interfaces;
using Test_Invoice.Infrastructure.DbContextConfig;

namespace Test_Invoice.Infrastructure.Repository;

public class InvoiceRepository: BaseRepository<Invoice>, IInvoice
{
    public InvoiceRepository(TestInvoiceContext context) : base(context)
    {
    }
}