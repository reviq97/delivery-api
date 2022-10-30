using delivery_api.Enitty;

namespace delivery_api.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(string id);
        void PostCustomer(Customer customer);

    }
}
