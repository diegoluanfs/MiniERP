using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniERP.Data;

namespace MiniERP.Repositories
{
    public class InvoiceRepository
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            var dbInvoice = await _context.Invoices.FindAsync(invoice.InvoiceId);
            if (dbInvoice != null)
            {
                // Atualize as propriedades conforme necessário.
                //dbInvoice.Property1 = invoice.Property1;
                //dbInvoice.Property2 = invoice.Property2;
                // ...

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var dbInvoice = await _context.Invoices.FindAsync(id);
            if (dbInvoice != null)
            {
                _context.Invoices.Remove(dbInvoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
