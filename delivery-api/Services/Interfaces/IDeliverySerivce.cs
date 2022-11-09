using delivery_api.Enitty;
using delivery_api.Models;

namespace delivery_api.Services.Interfaces
{
    public interface IDeliveryService
    {
        Delivery GetDelivery(string deliveryId);
        Delivery CreateDelivery(PostDeliveryDto deliveryDto);
        IEnumerable<Delivery> GetAllDeliveries();
        object GetDeliveryDetails(string deliveryId);
        void AssignArrivalDate(DateTime arrivalDate, string deliveryId);
        void DeleteDelivery(string deliveryId);
    }
}