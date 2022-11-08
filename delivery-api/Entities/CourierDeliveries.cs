using delivery_api.Enitty;

namespace delivery_api.Entities
{
    public class CourierDeliveries
    {
        public string CourierId { get; set; }
        public string CourierName { get; set; }
        public string CourierSurname { get; set; }

        public List<Delivery> Deliveries { get; set; }
    }
}
