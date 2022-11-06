using System.ComponentModel.DataAnnotations;

namespace delivery_api.Enitty
{
    public class Delivery
    {
        [Required]
        [Key]
        public string DeliveryId { get; set; }
        public string? CourierId { get; set; }
        [Required]
        public string SenderMail { get; set; }
        [Required]
        public string RecipientMail { get; set; }
        [Required]
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ArriveTime { get; set; }
    }
}
