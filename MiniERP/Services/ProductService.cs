using System.Collections.Generic;
using System.Threading.Tasks;
using MiniERP.Data;
using MiniERP.Repositories;

namespace MiniERP.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(ReqProduct reqProduct)
        {
            var product = new Product();
            product.Customer = new Customer();
            product.Supplier = new Supplier();
            product.Name = reqProduct.Name;
            product.Price = reqProduct.Price;
            product.Customer = reqProduct.Customer;
            product.Supplier = reqProduct.Supplier;

            await _repository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }
    }
}
