using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Repository;
using delivery_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Courier CreateCourier(CourierDto courierDto)
        {
            if(!_dbContext.Couriers.Any(x => x.PESEL == courierDto.PESEL))
            {
                var courier = new Courier()
                {
                    Name = courierDto.Name,
                    Surname = courierDto.Surname,
                    PESEL = courierDto.PESEL
                };

                _dbContext.Couriers.Add(courier);
                _dbContext.SaveChanges();
                return courier;
            }

            throw new Exception("Courier already exists in database");

        }

        public object GetCourierDeliveries(long courierId)
        {
            var courierDeliveries = _dbContext.Deliveries.Where(x => x.CourierId == courierId);

            var result = courierDeliveries.Select(x => new { Sender = x.SenderMail, Recipient = x.RecipientMail });

            var query = from d in _dbContext.Deliveries
                    join e in _dbContext.Customers
                    on d.RecipientMail equals e.Email
                    join h in _dbContext.Customers
                    on d.SenderMail equals h.Email
                    where d.CourierId == courierId
                    select new 
                    {
                        Courier = courierId,
                        Sender = new CustomerDto
                        {
                            Name = h.Name,
                            Surname = h.Surname,
                            PostalCode = h.PostalCode,
                            Street = h.Street,
                            City = h.City
                        },
                        Recipient = new CustomerDto
                        {
                            Name = e.Name,
                            Surname = e.Surname,
                            PostalCode = e.PostalCode,
                            Street = e.Street,
                            City = e.City
                        },

                        DeliveryId = d.DeliveryId,
                        DeliveryDetails = d.DeliveryDetails,
                        Arrive = d.ArriveTime,
                        Created = d.CreatedDate,
                    };

            // Cast to created data type

            return query.ToList();
        }
    }
}
