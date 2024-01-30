using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using API.Controllers.Simulators.Models;
using Newtonsoft.Json;

namespace API.Controllers.Simulators
{
    [Route("api/position-simulator")]
    public class PositionSimulatorController: BaseApiController
    {
        private readonly RabbitMqConnectionString _rabbitMqConnectionString;

        public PositionSimulatorController(RabbitMqConnectionString rabbitMqConnectionString)
        {
            _rabbitMqConnectionString = rabbitMqConnectionString;
        }

        [HttpPost("activate-simulator")]
        public Task<IActionResult> ActivateSimulator([FromBody] ActivationMessage message)
        {
            try
            {
                var factory = _rabbitMqConnectionString.CreateFactory();
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                var messageJson = JsonConvert.SerializeObject(message);
                var messageBytes = Encoding.UTF8.GetBytes(messageJson);

                channel.QueueDeclare(queue: "activation-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.BasicPublish(exchange: "", routingKey: "activation-queue", basicProperties: null, body: messageBytes);

                return Task.FromResult<IActionResult>(Ok("Activation started"));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500, "Internal Server Error"));
            }
        }
    }
}