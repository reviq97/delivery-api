namespace delivery_api.Enitty
{
    public class Delivery
    {
        public string DeliveryId { get; set; }
        public string PersonId { get; set; }
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ArriveTime { get; set; }
    }
}
