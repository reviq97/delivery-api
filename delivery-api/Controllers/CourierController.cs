using delivery_api.Enitty;
using delivery_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace delivery_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourierController : ControllerBase
    {

        private readonly ILogger<CourierController> _logger;
        private ICourierSerivce _deliveryService;

        public CourierController(ILogger<CourierController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Delivery> GetDelivery(string deliveryId)
        {
            var delivery = _deliveryService.GetDelivery(deliveryId);

            if(delivery == null)
            {
                throw new Exception("Delivery not found");
            }

            return Ok(delivery);
        }

        
    }
}