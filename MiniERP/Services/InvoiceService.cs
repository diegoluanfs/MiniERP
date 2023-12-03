using System.Collections.Generic;
using System.Threading.Tasks;
using MiniERP.Data;
using MiniERP.Repositories;

namespace MiniERP.Services
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _repository;

        public InvoiceService(InvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _repository.GetAllInvoicesAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _repository.GetInvoiceByIdAsync(id);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _repository.AddInvoiceAsync(invoice);
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            await _repository.UpdateInvoiceAsync(invoice);
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            await _repository.DeleteInvoiceAsync(id);
        }
    }
}
