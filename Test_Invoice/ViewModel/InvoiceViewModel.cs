using Test_Invoice.Common.Entities;

namespace Test_Invoice.ViewModel;

public class InvoiceViewModel
{
    public List<Invoice> Invoices { get; set; }
    public List<InvoiceDetail> InvoiceDetails { get; set; }
    
    public int CustomerId { get; set; }

    public decimal TotalItbis { get; set; }

    public decimal SubTotal { get; set; }
    
    public int Qty { get; set; }

    public decimal Price { get; set; }

    public decimal Total { get; set; }

}