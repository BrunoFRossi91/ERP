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
    public class EmployeeController : ControllerBase
    {
        private readonly GDRContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto dto)
        {
            var entity = _mapper.Map<EntityEmployee>(dto);
            entity.CreatedAt = DateTime.Now;

            await _context.Employee.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = entity.Id }, entity.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var entity = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDto>(entity));
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
        {
            var list = await _context.Employee.ToListAsync();
            return Ok(_mapper.Map<List<EmployeeDto>>(list));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto dto)
        {
            var entity = await _context.Employee.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null)
                return NotFound();

            dto.UpdatedAt = DateTime.Now;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var entity = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                return NotFound();

            _context.Employee.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
