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
        [Route("getDeliveryById")]
        public ActionResult<Delivery> GetDeliveryById([FromQuery]string deliveryId)
        {
            var delivery = _deliveryService.GetDelivery(deliveryId);

            return Ok(delivery);
        }

        [HttpGet]
        [Route("getAllDeliveries")]
        public ActionResult<IEnumerable<Delivery>> GetAllDeliveries()
        {
            var deliveries = _deliveryService.GetAllDeliveries();

            return Ok(deliveries);
        }

        [HttpPost]
        [Route("createDelivery")]
        public ActionResult CreateDelivery([FromBody] PostDeliveryDto deliveryDto)
        {
            var delivery = _deliveryService.CreateDelivery(deliveryDto);

            return Created(string.Empty, delivery);
        }

        [HttpGet]
        [Route("getDeliveryDetails")]
        public ActionResult<object> GetDeliveryDetails([FromQuery] string deliveryId)
        {
            var deliveryDetails = _deliveryService.GetDeliveryDetails(deliveryId);

            return Ok(deliveryDetails);
        }

        

        [HttpPatch]
        [Route("assignArrivalDateToDelivery")]
        public ActionResult AssignArrivalDateToDelivery([FromQuery] DateTime arrivalDate, [FromQuery] string deliveryId)
        {
            _deliveryService.AssignArrivalDate(arrivalDate, deliveryId);

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteDelivery")]
        public ActionResult DeleteDelivery([FromQuery] string deliveryId)
        {
            _deliveryService.DeleteDelivery(deliveryId);

            return NoContent();
        }
    }
}