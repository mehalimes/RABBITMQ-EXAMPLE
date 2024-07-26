using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Publisher.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<ActionResult> sendOrder([FromBody] Order order)
        {
            Uri uri = new Uri("rabbitmq://localhost/orderQueue");
            ISendEndpoint endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(order);
            return Ok();
        }
    }
}
