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
    public class PackageController : ControllerBase
    {
        private readonly GDRContext _context;
        private readonly IMapper _mapper;

        public PackageController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPackage([FromBody] PackageDto dto)
        {
            var entity = _mapper.Map<EntityPackage>(dto);
            entity.CreatedAt = DateTime.Now;

            await _context.Package.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(entity.Id);
        }

        [HttpGet]
        public async Task<ActionResult<PackageDto>> GetPackageById(int id)
        {
            var package = await _context.Package
                .Include(p => p.Company)
                .Include(p => p.Customer)
                .Include(p => p.Service)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (package == null)
                return NotFound();

            //var daysUsed = await _context.Schedules
            //    .Where(s => s.ServiceDate >= package.StartDate && s.ServiceDate <= package.EndDate)
            //    .CountAsync(s => s.PackageId == id);

            var dto = new PackageDto
            {
                Id = package.Id,
                Name = package.Name,
                CompanyId = package.CompanyId,
                CompanyName = package.Company?.Name ?? string.Empty,
                CustomerId = package.CustomerId,
                CustomerName = package.Customer?.Name ?? string.Empty,
                ServiceId = package.ServiceId,
                ServiceName = package.Service?.Name ?? string.Empty,
                StartDate = package.StartDate,
                EndDate = package.EndDate,
                Price = package.Price,
                TotalDays = package.NumberOfDays,
                CreatedAt = package.CreatedAt,
                UpdatedAt = package.UpdatedAt,
                //DaysUsed = daysUsed
            };

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<PackageDto>>> GetAllPackages()
        {
            var packages = await _context.Package
                .Include(p => p.Company)
                .Include(p => p.Customer)
                .Include(p => p.Service)
                .ToListAsync();

            var result = packages.Select(p => new PackageDto
            {
                Id = p.Id,
                Name = p.Name,
                CompanyId = p.CompanyId,
                CompanyName = p.Company?.Name ?? string.Empty,
                CustomerId = p.CustomerId,
                CustomerName = p.Customer?.Name ?? string.Empty,
                ServiceId = p.ServiceId,
                ServiceName = p.Service?.Name ?? string.Empty,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Price = p.Price,
                TotalDays = p.NumberOfDays,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePackage([FromBody] PackageDto dto)
        {
            var package = await _context.Package.FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (package == null)
                return NotFound();

            package.UpdatedAt = DateTime.Now;
            _mapper.Map(dto, package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePackage(int id)
        {
            var package = await _context.Package.FirstOrDefaultAsync(p => p.Id == id);

            if (package == null)
                return NotFound();

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> GetPackageComboByCompanyAndCustomer(int companyId, string customerEmail)
        {
            var customerId = await _context.Customer
                .Where(c => c.Email == customerEmail)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            var combo = await _context.Package
                .Where(p => p.CompanyId == companyId && p.CustomerId == customerId)
                .Select(p => new ComboxDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            return Ok(combo);
        }
    }
}
