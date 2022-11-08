using delivery_api.Enitty;
using System.ComponentModel.DataAnnotations;

namespace delivery_api.Models
{
    public class DeliveryDto
    {
        [Required]
        public CustomerDto Sender { get; set; }
        [Required]
        public CustomerDto Recipient { get; set; }
        [Required]
        public string DeliveryDetails { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
