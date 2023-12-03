using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniERP.Data;

namespace MiniERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly DataContext _context;

        public SupplierController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> Get()
        {
            return Ok(await _context.Suppliers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> Get(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
                return BadRequest("Supplier not found.");
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<List<Supplier>>> AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return Ok(await _context.Suppliers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Supplier>>> UpdateSupplier(Supplier request)
        {
            var dbSupplier = await _context.Suppliers.FindAsync(request.SupplierId);
            if (dbSupplier == null)
                return BadRequest("Supplier not found.");

            // Atualize as propriedades conforme necessário
            //dbSupplier.Property1 = request.Property1;
            //dbSupplier.Property2 = request.Property2;
            // ...

            await _context.SaveChangesAsync();

            return Ok(await _context.Suppliers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Supplier>>> DeleteSupplier(int id)
        {
            var dbSupplier = await _context.Suppliers.FindAsync(id);
            if (dbSupplier == null)
                return BadRequest("Supplier not found.");

            _context.Suppliers.Remove(dbSupplier);
            await _context.SaveChangesAsync();

            return Ok(await _context.Suppliers.ToListAsync());
        }
    }
}
