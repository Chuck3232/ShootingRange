using Application.Commands.Customer;
using Application.Dto;
using Application.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto command)
        {
            await _customerServices.AddCustomer(command);
            return Ok();
        }
        [HttpGet]
        public ActionResult<List<CustomerDto>> GetAllCustomers()
        {
            return Ok(_customerServices.GetallCustomers());
        }
        [HttpPut("{customerId}")]
        public async Task<ActionResult> EditCustomerData(Guid CustomerId, [FromBody] CustomerUpdate command)
        {
            command.Id = CustomerId;
            await _customerServices.UpdateCustomer(command);
            return Ok();
        }
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(Guid customerId)
        {
            var command = new GetCustomerById { CustomerId = customerId};
            await _customerServices.DeleteCustomer(command);
            return Ok();
        }
    }
}
