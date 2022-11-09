using delivery_api.Enitty;
using delivery_api.Models;
using delivery_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace delivery_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly ICourierService _courierService;

        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [HttpGet]
        [Route("getCourierByPesel")]
        public ActionResult GetCourierByPesel([FromQuery] string pesel)
        {
            var courier = _courierService.GetCourier(pesel);

            return Ok(courier);
        }

        [HttpGet]
        [Route("getCourierAllDeliveries")]
        public ActionResult<object> GetCourierDeliveries([FromQuery] long courierId)
        {
            var courierDeliveries = _courierService.GetCourierDeliveries(courierId);

            return courierDeliveries;
        }

        [HttpPost]
        [Route("createCourier")]
        public ActionResult CreateCourier([FromBody] CourierDto courierDto)
        {
            var courier = _courierService.CreateCourier(courierDto);

            return Ok(courier);
        }

        [HttpPatch]
        [Route("assignCourierToDelivery")]
        public ActionResult AssignCourierToDelivery([FromQuery] long courierId, [FromQuery] string deliveryId)
        {
            _courierService.AssignCourierToDelivery(courierId, deliveryId);

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteCourier")]
        public ActionResult DeleteCourier([FromQuery] long courierId)
        {
            _courierService.DeleteCourier(courierId);

            return NoContent();
        }

    }
}
