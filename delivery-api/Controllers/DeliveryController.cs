using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace delivery_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly IDeliveryService _courierService;

        public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService)
        {
            _logger = logger;
            _courierService = deliveryService;
        }

        [HttpGet]
        public ActionResult<Delivery> GetDeliveryById(string deliveryId)
        {
            var delivery = _courierService.GetDelivery(deliveryId);

            if (delivery is null) return NotFound("There isn't such delivery with given delivery id");

            return Ok(delivery);
        }

        [HttpPost]
        public ActionResult PostDelivery([FromBody] DeliveryDto deliveryDto)
        {

            var delivery = _courierService.PostDelivery(deliveryDto);

            return Created(string.Empty, delivery);
        }

        
    }
}