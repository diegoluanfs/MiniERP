using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Data;
using MiniERP.Services;

namespace MiniERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return BadRequest("Customer not found.");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(ReqCustomer customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            await _customerService.UpdateCustomerAsync(request);
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok(await _customerService.GetAllCustomersAsync());
        }
    }
}
