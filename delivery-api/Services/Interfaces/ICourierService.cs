using delivery_api.Enitty;
using delivery_api.Models;

namespace delivery_api.Services.Interfaces
{
    public interface ICourierService
    {
        Courier GetCourier(string courierPesel);
        Courier CreateCourier(CourierDto courier);
        object GetCourierDeliveries(long courierId);
    }
}
