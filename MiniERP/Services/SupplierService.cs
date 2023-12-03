using System.Collections.Generic;
using System.Threading.Tasks;
using MiniERP.Data;
using MiniERP.Repositories;

namespace MiniERP.Services
{
    public class SupplierService
    {
        private readonly SupplierRepository _repository;

        public SupplierService(SupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _repository.GetAllSuppliersAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _repository.GetSupplierByIdAsync(id);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _repository.AddSupplierAsync(supplier);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            await _repository.UpdateSupplierAsync(supplier);
        }

        public async Task DeleteSupplierAsync(int id)
        {
            await _repository.DeleteSupplierAsync(id);
        }
    }
}
