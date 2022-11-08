using delivery_api.Enitty;
using delivery_api.Models;

namespace delivery_api.Services.Interfaces
{
    public interface IDeliveryService
    {
        Delivery GetDelivery(string deliveryId);
        Delivery PostDelivery(DeliveryDto deliveryDto);
        IEnumerable<Delivery> GetAllDeliveries();
    }
}