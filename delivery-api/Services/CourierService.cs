using delivery_api.Enitty;
using delivery_api.Entities;
using delivery_api.Repository;
using delivery_api.Services.Interfaces;

namespace delivery_api.Services
{
    public class CourierService : ICourierService
    {
        private readonly ApplicationDbContext _dbContext;

        public CourierService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Courier GetCourier(string courierPesel)
        {
            var courier = _dbContext.Couriers.FirstOrDefault(c => c.PESEL == courierPesel);

            if (courier is not null)
            {
                return courier;
            }

            throw new Exception("Courier not found");
        }

        public Courier CreateCourier(Courier courier)
        {
            if(!_dbContext.Couriers.Any(x => x.PESEL == courier.PESEL))
            {
                _dbContext.Couriers.Add(courier);
            }

            throw new Exception("Courier already exists in database");

        }

        public CourierDeliveries GetCourierDeliveries(string courierId)
        {
            var listOfDeliveries = _dbContext.Deliveries.ToList();
            var courierDeliveries = _dbContext.Couriers.Where(x => x.CourierId == courierId)
                    .Join(listOfDeliveries,
                    cId => cId.CourierId,
                    dId => dId.CourierId,
                    (courier, delivery) => new CourierDeliveries
                    {
                        CourierId = courier.CourierId,
                        CourierName = courier.Name,
                        CourierSurname = courier.Surname,
                        Deliveries = listOfDeliveries
                    }).FirstOrDefault();

            return courierDeliveries ?? new CourierDeliveries
            {
                CourierId = courierId,
            };
        }
    }
}
