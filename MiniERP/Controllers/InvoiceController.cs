using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniERP.Data;

namespace MiniERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly DataContext _context;

        public InvoiceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> Get()
        {
            return Ok(await _context.Invoices.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
                return BadRequest("Invoice not found.");
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<List<Invoice>>> AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok(await _context.Invoices.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Invoice>>> UpdateInvoice(Invoice request)
        {
            var dbInvoice = await _context.Invoices.FindAsync(request.InvoiceId);
            if (dbInvoice == null)
                return BadRequest("Invoice not found.");

            // Atualize as propriedades conforme necessário
            //dbInvoice.Property1 = request.Property1;
            //dbInvoice.Property2 = request.Property2;
            // ...

            await _context.SaveChangesAsync();

            return Ok(await _context.Invoices.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Invoice>>> DeleteInvoice(int id)
        {
            var dbInvoice = await _context.Invoices.FindAsync(id);
            if (dbInvoice == null)
                return BadRequest("Invoice not found.");

            _context.Invoices.Remove(dbInvoice);
            await _context.SaveChangesAsync();

            return Ok(await _context.Invoices.ToListAsync());
        }
    }
}
