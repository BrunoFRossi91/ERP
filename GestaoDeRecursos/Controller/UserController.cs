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
    public class UserController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public UserController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto dto)
        {
            var entityUser = _mapper.Map<EntityUser>(dto);
            entityUser.CreatedAt = DateTime.Now;

            await _context.User.AddAsync(entityUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = entityUser.Id }, entityUser.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.User
                .Include(u => u.Company)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            var dto = _mapper.Map<UserDto>(user);
            if (user.Company != null)
                dto.CompanyName = user.Company.Name;

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _context.User.Include(u => u.Company).ToListAsync();
            var dtos = _mapper.Map<List<UserDto>>(users);

            foreach (var dto in dtos)
            {
                var company = users.FirstOrDefault(u => u.Id == dto.Id)?.Company;
                dto.CompanyName = company?.Name ?? string.Empty;
            }

            return Ok(dtos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto dto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == dto.Id);

            if (user == null)
                return NotFound();

            dto.UpdatedAt = DateTime.Now;
            _mapper.Map(dto, user);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
