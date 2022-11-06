using delivery_api.Enitty;
using System.ComponentModel.DataAnnotations;

namespace delivery_api.Models
{
    public class DeliveryDto
    {
        public CustomerDto Sender { get; set; }
        public CustomerDto Recipient { get; set; }
        public string DeliveryDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
