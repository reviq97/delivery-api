using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Repository;
using delivery_api.Services.Interfaces;

namespace delivery_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetCustomer(string mail)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == mail);

            if(customer is null)
            {
                throw new Exception("Customer not found with given mail");
            }

            return customer;
        }

        public void PostCustomer(CustomerDto customerDto)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == customerDto.Email);

            if (customer is not null)
            {
                throw new Exception("Customer already exists");
            }

            var newCustomer = new Customer()
            {
                CustomerId = Guid.NewGuid().ToString(),
                Name = customerDto.Name,
                Surname = customerDto.Surname,
                City = customerDto.City,
                Email = customerDto.Email,
                Street = customerDto.Street,
                PostalCode = customerDto.PostalCode,
            };

            _dbContext.Customers.Add(newCustomer);
            _dbContext.SaveChanges();

        }
    }
}
