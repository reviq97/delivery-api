using System.ComponentModel.DataAnnotations;

namespace delivery_api.Enitty
{
    public class Delivery
    {
        [Required]
        [Key]
        public string DeliveryId { get; set; }

        public string? CourierId { get; set; }
        public Courier Courier { get; set; }
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string RecipientId { get; set; }
        [Required]
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ArriveTime { get; set; }
    }
}
