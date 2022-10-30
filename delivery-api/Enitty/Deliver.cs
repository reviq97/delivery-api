using System.ComponentModel.DataAnnotations;

namespace delivery_api.Enitty
{
    public class Delivery
    {
        [Required]
        public string DeliveryId { get; set; }
        [Required]
        public string PersonId { get; set; }
        [Required]
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ArriveTime { get; set; }
    }
}
