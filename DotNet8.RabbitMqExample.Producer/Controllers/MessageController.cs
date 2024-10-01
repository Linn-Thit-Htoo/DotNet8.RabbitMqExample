global using DotNet8.RabbitMqExample.Producer.Models;
global using Microsoft.AspNetCore.Mvc;

namespace DotNet8.RabbitMqExample.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageProducer _producer;

        public MessageController(IMessageProducer producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] BlogModel blog)
        {
            _producer.SendMessage(blog);
            return Ok("Success.");
        }
    }
}
