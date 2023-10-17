using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Invoice.Common.Entities;
using Test_Invoice.Common.interfaces;
using Test_Invoice.ViewModel;

namespace Test_Invoice.Controllers;

public class InvoiceController : Controller
{
    private readonly IInvoice _invoice;
    private readonly IInvoiceDetail _invoiceDetail;
    private readonly ICustomer _customer;

    public InvoiceController(IInvoice invoice, IInvoiceDetail invoiceDetail, ICustomer customer)
    {
        this._invoice = invoice;
        this._invoiceDetail = invoiceDetail;
        this._customer = customer;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetAllInvoice()
    {
      var getInvoice = await _invoice.GetAll();
        return View(getInvoice);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddInvoice()
    {
       var listCustomer = await _customer.GetAll();

       ViewBag.customers = listCustomer.Select(x => new SelectListItem
       {
           Text = x.CustName,
           Value = x.Id.ToString()
       });
       
       return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddInvoice(InvoiceDetail invoiceDetail)
    {
        if (invoiceDetail != null)
        {
            Invoice invoice = new Invoice()
            {
                CustomerId = invoiceDetail.CustomerId,
                TotalItbis = invoiceDetail.TotalItbis,
                SubTotal = invoiceDetail.SubTotal,
                Total = invoiceDetail.Total
            };
            
            await _invoice.Add(invoice);
            
            await _invoiceDetail.Add(invoiceDetail);
        }
        return new JsonResult(new { Message = "Se ha agregado con exito", id = 1});
    }
}