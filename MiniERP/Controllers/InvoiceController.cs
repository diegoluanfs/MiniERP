using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Data;
using MiniERP.Services;

namespace MiniERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> Get()
        {
            return Ok(await _invoiceService.GetAllInvoicesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return BadRequest("Invoice not found.");
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<List<Invoice>>> AddInvoice(Invoice invoice)
        {
            await _invoiceService.AddInvoiceAsync(invoice);
            return Ok(await _invoiceService.GetAllInvoicesAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Invoice>>> UpdateInvoice(Invoice request)
        {
            await _invoiceService.UpdateInvoiceAsync(request);
            return Ok(await _invoiceService.GetAllInvoicesAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Invoice>>> DeleteInvoice(int id)
        {
            await _invoiceService.DeleteInvoiceAsync(id);
            return Ok(await _invoiceService.GetAllInvoicesAsync());
        }
    }
}
