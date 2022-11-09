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

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return _dbContext.Deliveries;
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

        public Delivery CreateDelivery(PostDeliveryDto deliveryDto)
        {
            var delivery = new Delivery()
            {
                DeliveryId = Guid.NewGuid().ToString(),
                SenderMail = deliveryDto.Sender.Email,
                RecipientMail = deliveryDto.Recipient.Email,
                DeliveryDetails = deliveryDto.DeliveryDetails,
                CreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                ArriveTime = null,
            };

            var sender = _dbContext.Customers.FirstOrDefault(x => x.Email == deliveryDto.Sender.Email);
            var recipient = _dbContext.Customers.FirstOrDefault(x => x.Email == deliveryDto.Recipient.Email);

            if (sender is null)
            {
                _customerService.CreateCustomer(deliveryDto.Sender);
            }

            if(recipient is null)
            {
                _customerService.CreateCustomer(deliveryDto.Recipient);
            }

            _dbContext.Deliveries.Add(delivery);
            _dbContext.SaveChanges();
            return delivery;
            
        }

        public object GetDeliveryDetails(string deliveryId)
        {
            var delivery = _dbContext.Deliveries.FirstOrDefault(x => x.DeliveryId == deliveryId);

            if(delivery is null)
            {
                throw new Exception("Delivery not found");
            }

            var query = from d in _dbContext.Deliveries
                        join e in _dbContext.Customers
                        on d.RecipientMail equals e.Email
                        join h in _dbContext.Customers
                        on d.SenderMail equals h.Email
                        join c in _dbContext.Couriers
                        on d.CourierId equals c.CourierId
                        where d.DeliveryId == deliveryId
                        select new
                        {
                            Sender = new CustomerDto
                            {
                                Name = h.Name,
                                Surname = h.Surname,
                                Email = h.Email,
                                PostalCode = h.PostalCode,
                                Street = h.Street,
                                City = h.City
                            },
                            Recipient = new CustomerDto
                            {
                                Name = e.Name,
                                Surname = e.Surname,
                                Email = e.Email,
                                PostalCode = e.PostalCode,
                                Street = e.Street,
                                City = e.City
                            },

                            DeliveryId = d.DeliveryId,
                            CourierName = c.Name,
                            CourierSurname = c.Surname,
                            DeliveryDetails = d.DeliveryDetails,
                            Arrive = d.ArriveTime,
                            Created = d.CreatedDate,
                        };

            return query;
        }

        

        public void AssignArrivalDate(DateTime arrivalDate, string deliveryId)
        {
            var delivery = _dbContext.Deliveries.FirstOrDefault(x => x.DeliveryId == deliveryId);

            if (delivery is null)
            {
                throw new Exception("Delivery not found");
            }

            delivery.ArriveTime = DateTime.Parse(arrivalDate.ToString("yyyy-MM-dd"));

            _dbContext.Deliveries.Update(delivery);
            _dbContext.SaveChanges();
        }

        public void DeleteDelivery(string deliveryId)
        {
            var delivery = _dbContext.Deliveries.FirstOrDefault(x => x.DeliveryId == deliveryId);

            if(delivery is null)
            {
                throw new Exception("Delivery not found");
            }

            _dbContext.Deliveries.Remove(delivery);
            _dbContext.SaveChanges();
        }
    }
}
