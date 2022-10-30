using delivery_api.Enitty;
using delivery_api.Repository;
using delivery_api.Services.Interfaces;

namespace delivery_api.Services
{
    public class CourierService : ICourierSerivce
    {
        private readonly ApplicationDbContext _dbContext;

        public CourierService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Delivery GetDelivery(string deliveryId)
        {
            return _dbContext.Deliveries.FirstOrDefault(x => x.DeliveryId == deliveryId);
        }
    }
}
