using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Repository;
using delivery_api.Services.Interfaces;
using System.Linq;

namespace delivery_api.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerService _customerService;

        public DeliveryService(ApplicationDbContext dbContext, ICustomerService customerService)
        {
            _customerService = customerService;
            _dbContext = dbContext;
        }

        public Delivery GetDelivery(string deliveryId)
        {
            var delivery =_dbContext.Deliveries.FirstOrDefault(x => x.DeliveryId == deliveryId);

            if(delivery is not null)
            {
                return delivery;
            }

            throw new Exception("Delivery not found");
        }

        public Delivery PostDelivery(DeliveryDto deliveryDto)
        {
            var delivery = new Delivery()
            {
                DeliveryId = Guid.NewGuid().ToString(),
                CourierId = null,
                SenderMail = deliveryDto.Sender.Email,
                RecipientMail = deliveryDto.Recipient.Email,
                DeliveryDetails = deliveryDto.DeliveryDetails,
                CreatedDate = deliveryDto.CreatedDate,
                ArriveTime = null,
            };

            _dbContext.Deliveries.Add(delivery);

            var sender = deliveryDto.Sender.Email;
            var recipient = deliveryDto.Recipient.Email;

            if (!_dbContext.Customers.Any(x => x.Email == sender))
            {
                _customerService.PostCustomer(deliveryDto.Sender);
            }

            if(!_dbContext.Customers.Any(x => x.Email == recipient))
            {
                _customerService.PostCustomer(deliveryDto.Recipient);
            }

            _dbContext.SaveChanges();
            return delivery;
            
        }
    }
}
