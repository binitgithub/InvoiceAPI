using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceAPI.Models
{
    public class Invoice
    {
    public string InvoiceNumber { get; set; }
    public string CompanyName { get; set; }
    public string ClientName { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime DueDate { get; set; }
    }
}