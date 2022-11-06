using delivery_api.Enitty;
using delivery_api.Models;

namespace delivery_api.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(string id);
        void PostCustomer(CustomerDto customer);

    }
}
