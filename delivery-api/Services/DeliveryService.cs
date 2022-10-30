using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Repository;
using delivery_api.Services.Interfaces;

namespace delivery_api.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationDbContext _dbContext;

        public DeliveryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Delivery GetDelivery(string deliveryId)
        {
            return _dbContext.Deliveries.FirstOrDefault(x => x.DeliveryId == deliveryId);
        }

        public Delivery PostDelivery(DeliveryDto deliveryDto)
        {
            var delivery = new Delivery()
            {
                DeliveryId = Guid.NewGuid().ToString(),
                SenderId = deliveryDto.SenderId,
                RecipientId = deliveryDto.RecipientId,
                DeliveryDetails = deliveryDto.DeliveryDetails
            };

            if (_dbContext.Deliveries.Contains(delivery))
            {
                throw new Exception("Already exists delivery with that id");
            }

            _dbContext.Deliveries.Add(delivery);
            _dbContext.SaveChanges();

            return delivery;
        }
    }
}
