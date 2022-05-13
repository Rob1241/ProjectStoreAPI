using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectStore.Models;
using ProjectStore.Models.DTOs;
using AutoMapper;

namespace ProjectStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly DataBaseContext _dbcontext;
        private readonly IMapper _mapper;
        public CustomerController(DataBaseContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public ActionResult CreateCustomer([FromBody] CreateCustomerDTO CustomerDto)
        {
            var customer = _mapper.Map<Customer>(CustomerDto);
            _dbcontext.CustomerDbSet.Add(customer);
            _dbcontext.SaveChanges();
            return Created($"/api/Customer/{customer.Id}",null);
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer([FromRoute] int id)
        {
            var Customer = _dbcontext.CustomerDbSet.FirstOrDefault(b => b.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            var getcustomer = _mapper.Map<GetCustomerDTO>(Customer);
            return Ok(getcustomer);
        }
        [HttpPut("UpdatePassword/{id}")]
        public ActionResult UpdatePassword([FromBody] UpdatePassword EditUser, [FromRoute] int id)
        {
            var Customer = _dbcontext.CustomerDbSet.FirstOrDefault(b => b.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            Customer.Password = EditUser.Password;
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateEmail/{id}")]
        public ActionResult UpdateEmail([FromBody] UpdateEmail EditUser, [FromRoute] int id)
        {
            var Customer = _dbcontext.CustomerDbSet.FirstOrDefault(b => b.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            Customer.Email = EditUser.Email;
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateName/{id}")]
        public ActionResult UpdateName([FromBody] UpdateName EditUser, [FromRoute] int id)
        {
            var Customer = _dbcontext.CustomerDbSet.FirstOrDefault(b => b.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            Customer.Name = EditUser.Name;
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteCustomer([FromRoute] int id)
        {
            var Customer = _dbcontext.CustomerDbSet.FirstOrDefault(b => b.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            _dbcontext.CustomerDbSet.Remove(Customer);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
