using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Data;
using MiniERP.Repositories;
using MiniERP.Tools;

namespace MiniERP.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _repository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _repository.GetCustomerByIdAsync(id);
        }

        public async Task AddCustomerAsync(ReqCustomer reqCustomer)
        {
            var _sanitize = new Sanitize();

            if (string.IsNullOrWhiteSpace(reqCustomer.Name))
            {
                throw new Exception("Você deve entrar com um nome válido!");
            }

            reqCustomer.Name = reqCustomer.Name.Trim();

            var sanitizedName = _sanitize.ClearString(reqCustomer.Name);

            if (sanitizedName != reqCustomer.Name)
            {
                throw new Exception("O nome do cliente contém caracteres inválidos. Apenas letras são permitidas.");
            }

            var customer = new Customer();
            customer.Name = sanitizedName;

            await _repository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            Customer customerResp = await GetCustomerByIdAsync(customer.CustomerId);
            if (customerResp == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            await _repository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            Customer customerResp = await GetCustomerByIdAsync(id);
            if (customerResp == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            await _repository.DeleteCustomerAsync(id);
        }
    }
}
