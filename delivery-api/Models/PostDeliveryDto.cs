using System.ComponentModel.DataAnnotations;

namespace delivery_api.Models
{
    public class PostDeliveryDto
    {
        [Required]
        public CustomerDto Sender { get; set; }
        [Required]
        public CustomerDto Recipient { get; set; }
        [Required]
        public string DeliveryDetails { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Arrive { get; set; }
    }
}
