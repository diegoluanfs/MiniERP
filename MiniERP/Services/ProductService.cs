using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniERP.Data;
using MiniERP.Repositories;

namespace MiniERP.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        private readonly CustomerService _serviceCustomer;
        private readonly SupplierService _serviceSupplier;

        public ProductService(ProductRepository repository, CustomerService serviceCustomer, SupplierService serviceSupplier)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _serviceCustomer = serviceCustomer ?? throw new ArgumentNullException(nameof(serviceCustomer));
            _serviceSupplier = serviceSupplier ?? throw new ArgumentNullException(nameof(serviceSupplier));
        }

        public async Task<List<RespProduct>> GetAllProductsAsync()
        {
            var productList = await _repository.GetAllProductsAsync();
            return await ShowProducts(productList);
        }

        public async Task<RespProduct> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            return await MapProductToRespProduct(product);
        }

        public async Task<List<RespProduct>> AddProductAsync(ReqProduct reqProduct)
        {
            await VerifyProduct(reqProduct);

            var product = new Product
            {
                Name = reqProduct.Name,
                Price = reqProduct.Price,
                SupplierId = reqProduct.SupplierId
            };

            await _repository.AddProductAsync(product);
            return await GetAllProductsAsync();
        }

        public async Task<RespProduct> UpdateProductAsync(Product product)
        {
            await ValidateProductForUpdate(product);
            await _repository.UpdateProductAsync(product);
            return await GetProductByIdAsync(product.ProductId);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }

        private async Task<List<RespProduct>> ShowProducts(List<Product> productList)
        {
            var result = new List<RespProduct>();
            foreach (var item in productList)
            {
                var respProduct = await MapProductToRespProduct(item);
                result.Add(respProduct);
            }
            return result;
        }

        private async Task<RespProduct> MapProductToRespProduct(Product product)
        {
            var supplier = await MapSupplierAsync(product.SupplierId);

            return new RespProduct
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Supplier = supplier
            };
        }

        private async Task<Customer> MapCustomerAsync(int customerId)
        {
            var customerResp = await _serviceCustomer.GetCustomerByIdAsync(customerId);
            return new Customer
            {
                Name = customerResp.Name,
                CustomerId = customerResp.CustomerId
            };
        }

        private async Task<Supplier> MapSupplierAsync(int supplierId)
        {
            var supplierResp = await _serviceSupplier.GetSupplierByIdAsync(supplierId);
            return new Supplier
            {
                Name = supplierResp.Name,
                SupplierId = supplierResp.SupplierId
            };
        }

        private async Task VerifyProduct(ReqProduct reqProduct)
        {
            if (await _serviceSupplier.GetSupplierByIdAsync(reqProduct.SupplierId) == null)
            {
                throw new Exception("Fornecedor não encontrado.");
            }

            if (string.IsNullOrEmpty(reqProduct.Name))
            {
                throw new Exception("O nome do produto não pode estar vazio.");
            }

            if (reqProduct.Price <= 0)
            {
                throw new Exception("O valor do produto deve ser maior que zero.");
            }
        }

        private async Task ValidateProductForUpdate(Product product)
        {
            var existingProduct = await _repository.GetProductByIdAsync(product.ProductId);
            if (existingProduct == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            if (await _serviceSupplier.GetSupplierByIdAsync(product.SupplierId) == null)
            {
                throw new Exception("Fornecedor não encontrado.");
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                throw new Exception("O nome do produto não pode estar vazio.");
            }

            if (product.Price <= 0)
            {
                throw new Exception("O valor do produto deve ser maior que zero.");
            }
        }
    }
}
