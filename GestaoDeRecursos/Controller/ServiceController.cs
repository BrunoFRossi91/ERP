using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServiceController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public ServiceController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServiceDto dto)
        {
            var entity = _mapper.Map<EntityService>(dto);
            entity.CreatedAt = DateTime.Now;

            await _context.Service.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceById), new { id = entity.Id }, entity.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _context.Service
                .Include(s => s.Company)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
                return NotFound();

            var dto = new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                CompanyId = service.CompanyId,
                CompanyName = service.Company?.Name ?? string.Empty,
                CreatedAt = service.CreatedAt,
                UpdatedAt = service.UpdatedAt
            };

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetAllServices()
        {
            var services = await _context.Service
                .Include(s => s.Company)
                .ToListAsync();

            var result = services.Select(s => new ServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                CompanyId = s.CompanyId,
                CompanyName = s.Company?.Name ?? string.Empty,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            }).ToList();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] ServiceDto dto)
        {
            var service = await _context.Service.FirstOrDefaultAsync(s => s.Id == dto.Id);

            if (service == null)
                return NotFound();

            dto.UpdatedAt = DateTime.Now;
            _mapper.Map(dto, service);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Service.FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
                return NotFound();

            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> GetServiceComboByCompany(int companyId)
        {
            var combo = await _context.Service
                .Where(s => s.CompanyId == companyId)
                .Select(s => new ComboxDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();

            return Ok(combo);
        }
    }
}
