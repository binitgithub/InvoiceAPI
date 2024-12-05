using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceAPI.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
         [HttpPost("generate")]
    public IActionResult GenerateInvoice([FromBody] Invoice invoice)
    {
        try
        {
            var filePath = Path.Combine(Path.GetTempPath(), $"{invoice.InvoiceNumber}.pdf");

            using (var writer = new PdfWriter(filePath))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                document.Add(new Paragraph($"Invoice Number: {invoice.InvoiceNumber}"));
                document.Add(new Paragraph($"Company Name: {invoice.CompanyName}"));
                document.Add(new Paragraph($"Client Name: {invoice.ClientName}"));
                document.Add(new Paragraph($"Description: {invoice.Description}"));
                document.Add(new Paragraph($"Amount: {invoice.Currency} {invoice.Amount}"));
                document.Add(new Paragraph($"Due Date: {invoice.DueDate:dd-MM-yyyy}"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", $"{invoice.InvoiceNumber}.pdf");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    }
}