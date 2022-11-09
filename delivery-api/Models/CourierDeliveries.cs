using delivery_api.Enitty;

namespace delivery_api.Models
{
    public class CourierDeliveries
    {
        public long CourierId { get; set; }
        public string CourierName { get; set; }
        public string CourierSurname { get; set; }

        public List<DeliveryDto> DeliveryInfo { get; set; }
    }
}
