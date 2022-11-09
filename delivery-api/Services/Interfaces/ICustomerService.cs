using delivery_api.Enitty;
using delivery_api.Models;

namespace delivery_api.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomerByMail(string mail);
        void CreateCustomer(CustomerDto customer);
        IEnumerable<Customer> GetAllCustomers();
        void DeleteCustomer(long customerId);
    }
}
