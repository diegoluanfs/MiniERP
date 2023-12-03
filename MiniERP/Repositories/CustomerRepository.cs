using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniERP.Data;

namespace MiniERP.Repositories
{
    public class CustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var dbCustomer = await _context.Customers.FindAsync(customer.CustomerId);
            if (dbCustomer != null)
            {
                dbCustomer.Name = customer.Name;
                // Atualize outras propriedades conforme necessário.
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var dbCustomer = await _context.Customers.FindAsync(id);
            if (dbCustomer != null)
            {
                _context.Customers.Remove(dbCustomer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
