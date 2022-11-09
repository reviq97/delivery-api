using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery_api.Enitty
{
    public class Delivery
    {
        [Required]
        [Key]
        public string DeliveryId { get; set; }
        [Required]
        public string SenderMail { get; set; }
        [Required]
        public string RecipientMail { get; set; }
        [Required]
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime? ArriveTime { get; set; }

        public long? CourierId { get; set; }

    }
}
