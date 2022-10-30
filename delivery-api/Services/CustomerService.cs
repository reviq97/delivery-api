using delivery_api.Enitty;
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

        public Customer GetCustomer(string id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == id);

            if(customer is null)
            {
                throw new Exception("Customer not found with given id");
            }

            return customer;
        }

        public void PostCustomer(Customer customer)
        {
            if(GetCustomer(customer.CustomerId) is null)
            {
                throw new Exception("Customer already exist");
            }

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
    }
}
