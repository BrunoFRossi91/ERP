using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly GDRContext _context;
        private readonly IMapper _mapper;

        public CustomerController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDto customer)
        {
            var entityCustomer = _mapper.Map<EntityCustomer>(customer);
            entityCustomer.CreatedAt = DateTime.Now;
            entityCustomer.UpdatedAt = null;
            _context.Customer.Add(entityCustomer);
            _context.SaveChanges();

            int customerId = entityCustomer.Id;

            var entityCustomerUser = new EntityCustomerUser
            {
                CustomerId = customerId,
                CompanyId = customer.CompanyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            _context.CustomerUser.Add(entityCustomerUser);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet]
        public List<EntityCustomer> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] CustomerDto data)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == data.Id);

            if (customer == null)
                return NotFound();

            customer.UpdatedAt = DateTime.Now;
            _mapper.Map(data, customer);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            _context.Customer.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
