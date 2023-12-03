using System.Collections.Generic;
using System.Threading.Tasks;
using MiniERP.Data;
using MiniERP.Repositories;
using MiniERP.Tools;

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

        public async Task AddSupplierAsync(ReqSupplier reqSupplier)
        {
            var _sanitize = new Sanitize();

            if (string.IsNullOrWhiteSpace(reqSupplier.Name))
            {
                throw new Exception("Você deve entrar com um nome válido!");
            }

            reqSupplier.Name = reqSupplier.Name.Trim();

            var sanitizedName = _sanitize.ClearString(reqSupplier.Name);

            if (sanitizedName != reqSupplier.Name)
            {
                throw new Exception("O nome do fornecedor contém caracteres inválidos. Apenas letras são permitidas.");
            }

            Supplier supplier = new Supplier();
            supplier.Name= sanitizedName;

            await _repository.AddSupplierAsync(supplier);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            Supplier respSupplier = await GetSupplierByIdAsync(supplier.SupplierId);
            if (respSupplier != null)
            {
                throw new Exception("Fornecedor não encontrado!");
            }

            await _repository.UpdateSupplierAsync(supplier);
        }

        public async Task DeleteSupplierAsync(int id)
        {
            Supplier respSupplier = await GetSupplierByIdAsync(id);
            if (respSupplier != null)
            {
                throw new Exception("Fornecedor não encontrado!");
            }

            await _repository.DeleteSupplierAsync(id);
        }
    }
}
