using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Services;
using delivery_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace delivery_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Route("getAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet]
        [Route("getCustomerByMail")]
        public ActionResult<Customer> GetCustomerByMail([FromQuery] string mail)
        {
            var customer = _customerService.GetCustomerByMail(mail);

            return Ok(customer);
        }

        [HttpPost]
        [Route("createCustomer")]
        public ActionResult CreateCustomer([FromBody] CustomerDto customer)
        {
            _customerService.CreateCustomer(customer);

            return Created(string.Empty, customer);
        }

        [HttpDelete]
        [Route("deleteCustomer")]
        public ActionResult DeleteCustomer([FromQuery] long customerId)
        {
            _customerService.DeleteCustomer(customerId);

            return NoContent();
        }
    }
}
