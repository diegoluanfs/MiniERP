using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniERP.Data;
using MiniERP.Services;

namespace MiniERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SupplierController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<Supplier>>> Get()
        {
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return BadRequest("Supplier not found.");
            return Ok(supplier);
        }

        [HttpPost]
        [Route("AddSupplier")]
        public async Task<ActionResult<List<Supplier>>> AddSupplier(Supplier supplier)
        {
            await _supplierService.AddSupplierAsync(supplier);
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        [HttpPut]
        [Route("UpdateSupplier")]
        public async Task<ActionResult<List<Supplier>>> UpdateSupplier(Supplier request)
        {
            await _supplierService.UpdateSupplierAsync(request);
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        [HttpDelete]
        [Route("DeleteSupplier")]
        public async Task<ActionResult<List<Supplier>>> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }
    }
}
