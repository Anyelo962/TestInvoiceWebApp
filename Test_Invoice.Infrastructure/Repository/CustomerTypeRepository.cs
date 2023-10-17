using Test_Invoice.Common.Entities;
using Test_Invoice.Common.interfaces;
using Test_Invoice.Infrastructure.DbContextConfig;

namespace Test_Invoice.Infrastructure.Repository;

public class CustomerTypeRepository: BaseRepository<CustomerType>, ICustomerType
{
    public CustomerTypeRepository(TestInvoiceContext context) : base(context)
    {
    }
}