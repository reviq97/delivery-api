using delivery_api.Enitty;
using delivery_api.Entities;

namespace delivery_api.Services.Interfaces
{
    public interface ICourierService
    {
        Courier GetCourier(string courierPesel);
        Courier CreateCourier(Courier courier);
        CourierDeliveries GetCourierDeliveries(string courierId);
    }
}
