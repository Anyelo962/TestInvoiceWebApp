using System;
using System.Collections.Generic;

namespace Test_Invoice.Common.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string CustName { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public bool? Status { get; set; }

    public int CustomerTypeId { get; set; }

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
