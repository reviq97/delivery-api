using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Services;
using delivery_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace delivery_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<Customer> GetCustomerById(string customerId)
        {
            var customer = _customerService.GetCustomer(customerId);

            if (customer is null) return NotFound("There isn't such customer with given customer id");

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult PostCustomer([FromBody] CustomerDto customer)
        {
            _customerService.PostCustomer(customer);

            return Ok();
        }
    }
}
