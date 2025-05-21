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
    public class ProductController : ControllerBase
    {
        private readonly GDRContext _context;
        private readonly IMapper _mapper;

        public ProductController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto dto)
        {
            var entity = _mapper.Map<EntityProduct>(dto);
            entity.CreatedAt = DateTime.Now;

            await _context.Product.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = entity.Id }, entity.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var entity = await _context.Product.Include(p => p.Company).FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null)
                return NotFound();

            var dto = _mapper.Map<ProductDto>(entity);
            if (entity.Company != null)
                dto.CompanyName = entity.Company.Name;

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var list = await _context.Product.Include(p => p.Company).ToListAsync();
            var dtos = _mapper.Map<List<ProductDto>>(list);

            foreach (var dto in dtos)
            {
                var company = list.FirstOrDefault(p => p.Id == dto.Id)?.Company;
                dto.CompanyName = company?.Name ?? string.Empty;
            }

            return Ok(dtos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto dto)
        {
            var entity = await _context.Product.FirstOrDefaultAsync(p => p.Id == dto.Id);
            if (entity == null)
                return NotFound();

            dto.UpdatedAt = DateTime.Now;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var entity = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null)
                return NotFound();

            _context.Product.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
