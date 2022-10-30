using delivery_api.Enitty;

namespace delivery_api.Services.Interfaces
{
    internal interface ICourierSerivce
    {
        Delivery GetDelivery(string deliveryId);
    }
}