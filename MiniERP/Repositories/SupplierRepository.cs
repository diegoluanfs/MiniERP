using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniERP.Data;

namespace MiniERP.Repositories
{
    public class SupplierRepository
    {
        private readonly DataContext _context;

        public SupplierRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            var dbSupplier = await _context.Suppliers.FindAsync(supplier.SupplierId);
            if (dbSupplier != null)
            {
                // Atualize as propriedades conforme necessário.
                //dbSupplier.Property1 = supplier.Property1;
                //dbSupplier.Property2 = supplier.Property2;
                // ...

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var dbSupplier = await _context.Suppliers.FindAsync(id);
            if (dbSupplier != null)
            {
                _context.Suppliers.Remove(dbSupplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
