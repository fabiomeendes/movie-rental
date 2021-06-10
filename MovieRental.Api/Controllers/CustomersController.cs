using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RentalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
   
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return Ok(new RequestDTO<List<Customer>> { Data = _customerRepository.ListCustomers().ToList() });
        }

        [HttpPost]
        public ActionResult Post([FromBody] CustomerDTO model)
        {
            var customers = _customerRepository.ListCustomers();

            var c = customers.Where(x => x.Email == model.Email);

            if (c != null && c.Count() > 0)
            {
                return BadRequest(new RequestDTO<Customer> { Status = HttpStatusCode.BadRequest, Message = "Customer already exists" });
            }

            _customerRepository.CreateCustomer(new Customer
            {
                Email = model.Email,
                Name = model.Email,
                IsActive = true
            });

            return Ok(new RequestDTO<Customer> { Status = HttpStatusCode.Created, Message = "Data Successfully" });
        }

        [HttpDelete("{customerId}")]
        public ActionResult Delete(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            customer.IsActive = false;
            _customerRepository.DeleteCustomer(customer);

            return Ok(new RequestDTO<Customer> { Status = HttpStatusCode.OK, Message = "Data Successfully" });
        }
    }
}
