using delivery_api.Enitty;
using delivery_api.Entities;
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
        public ActionResult GetCourierByPesel([FromQuery] string pesel)
        {
            var courier = _courierService.GetCourier(pesel);

            return Ok(courier);
        }

        [HttpGet]
        public ActionResult<CourierDeliveries> GetCourierDeliveries([FromQuery] string courierId)
        {
            var courierDeliveries = _courierService.GetCourierDeliveries(courierId);

            return courierDeliveries;
        }

        // TODO: Finish controller, then test GetCourierDeliveries, seed some deliveries with same courier id
        /*[HttpPost]
        public ActionResult CreateCourier([FromBody] Courier courier)
        {

        }*/

    }
}
