using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SupplierController : ControllerBase
    {
        private readonly GDRContext _context;
        private readonly IMapper _mapper;

        public SupplierController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierDto dto)
        {
            var entity = _mapper.Map<EntitySupplier>(dto);
            entity.CreatedAt = DateTime.Now;

            await _context.Supplier.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplierById), new { id = entity.Id }, entity.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var entity = await _context.Supplier.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                return NotFound();

            return Ok(_mapper.Map<SupplierDto>(entity));
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAllSuppliers()
        {
            var list = await _context.Supplier.ToListAsync();
            return Ok(_mapper.Map<List<SupplierDto>>(list));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierDto dto)
        {
            var entity = await _context.Supplier.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null)
                return NotFound();

            dto.UpdatedAt = DateTime.Now;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var entity = await _context.Supplier.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                return NotFound();

            _context.Supplier.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
