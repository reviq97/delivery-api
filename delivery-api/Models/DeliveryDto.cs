namespace delivery_api.Models
{
    public class DeliveryDto
    {
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ArriveTime { get; set; }
    }
}
