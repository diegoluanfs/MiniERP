﻿using System.Collections.Generic;
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
        public async Task<ActionResult<List<Supplier>>> Get()
        {
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return BadRequest("Supplier not found.");
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<List<Supplier>>> AddSupplier(ReqSupplier reqSupplier)
        {
            await _supplierService.AddSupplierAsync(reqSupplier);
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Supplier>>> UpdateSupplier(Supplier request)
        {
            await _supplierService.UpdateSupplierAsync(request);
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Supplier>>> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }
    }
}
