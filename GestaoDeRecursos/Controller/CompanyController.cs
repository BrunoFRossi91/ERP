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
    public class CompanyController : ControllerBase
    {
        private readonly GDRContext _context;
        private readonly IMapper _mapper;

        public CompanyController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] CompanyDto companyDto)
        {
            var entity = _mapper.Map<EntityCompany>(companyDto);
            await _context.Company.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(entity.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c => c.Id == id);

            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityCompany>>> GetAllCompanies()
        {
            var companies = await _context.Company.ToListAsync();
            return Ok(companies);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyDto dto)
        {
            var existing = await _context.Company.FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c => c.Id == id);

            if (company == null)
                return NotFound();

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> GetCompanyCombobox()
        {
            var list = await _context.Company
                .Select(c => new ComboxDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return Ok(list);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> GetCompaniesByCustomerId(int customerId)
        {
            var companyIds = await _context.CustomerUser
                .Where(c => c.Id == customerId)
                .Select(c => c.CustomerId)
                .Distinct()
                .ToListAsync();

            var companies = await _context.Company
                .Where(c => companyIds.Contains(c.Id))
                .Select(c => new ComboxDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return Ok(companies);
        }
    }
}
