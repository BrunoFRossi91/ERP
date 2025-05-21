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
    public class CustomerUserController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public CustomerUserController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerUser([FromBody] CustomerUserDto dto)
        {
            var entityCustomerUser = _mapper.Map<EntityCustomerUser>(dto);
            entityCustomerUser.CreatedAt = DateTime.Now;

            await _context.CustomerUser.AddAsync(entityCustomerUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerUserById), new { id = entityCustomerUser.Id }, entityCustomerUser.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerUserById(int id)
        {
            var customerUser = await _context.CustomerUser.FirstOrDefaultAsync(cu => cu.Id == id);

            if (customerUser == null)
                return NotFound();

            var dto = _mapper.Map<CustomerUserDto>(customerUser);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerUserDto>>> GetAllCustomerUsers()
        {
            var users = await _context.CustomerUser.ToListAsync();
            var dtos = _mapper.Map<List<CustomerUserDto>>(users);
            return Ok(dtos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerUser([FromBody] CustomerUserDto dto)
        {
            var customerUser = await _context.CustomerUser.FirstOrDefaultAsync(cu => cu.Id == dto.Id);

            if (customerUser == null)
                return NotFound();

            dto.ModifiedAt = DateTime.Now;
            _mapper.Map(dto, customerUser);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerUser(int id)
        {
            var customerUser = await _context.CustomerUser.FirstOrDefaultAsync(cu => cu.Id == id);

            if (customerUser == null)
                return NotFound();

            _context.CustomerUser.Remove(customerUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
