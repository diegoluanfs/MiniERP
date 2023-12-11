using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniERP.Data;

namespace MiniERP.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            var resp = await _context.SaveChangesAsync();
            return resp;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.ProductId);
            if (dbProduct != null)
            {
                dbProduct.SupplierId = product.SupplierId;
                dbProduct.ProductId = product.ProductId;
                dbProduct.Name = product.Name;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct != null)
            {
                _context.Products.Remove(dbProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
