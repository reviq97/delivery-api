using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace delivery_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService)
        {
            _logger = logger;
            _deliveryService = deliveryService;
        }

        [HttpGet]
        [Route("id")]
        public ActionResult<Delivery> GetDeliveryById([FromQuery]string deliveryId)
        {
            var delivery = _deliveryService.GetDelivery(deliveryId);

            if (delivery is null) return NotFound("There isn't such delivery with given delivery id");

            return Ok(delivery);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Delivery>> GetAllDeliveries()
        {
            var deliveries = _deliveryService.GetAllDeliveries();

            return Ok(deliveries.Select(x => new Delivery
            {
                CourierId = x.CourierId,
                SenderMail = x.SenderMail,
                RecipientMail = x.RecipientMail,
                CreatedDate = x.CreatedDate,
                ArriveTime = x.ArriveTime,
                DeliveryDetails = x.DeliveryDetails,
                DeliveryId = x.DeliveryId
            }) ?? Enumerable.Empty<Delivery>());
        }

        [HttpPost]
        public ActionResult PostDelivery([FromBody] DeliveryDto deliveryDto)
        {

            var delivery = _deliveryService.PostDelivery(deliveryDto);

            return Created(string.Empty, delivery);
        }

        
    }
}