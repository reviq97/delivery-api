using delivery_api.Enitty;

namespace delivery_api.Services.Interfaces
{
    public interface ICourierService
    {
        Courier GetCourier(string courierPesel);
        Courier CreateCourier(Courier courier);
    }
}
