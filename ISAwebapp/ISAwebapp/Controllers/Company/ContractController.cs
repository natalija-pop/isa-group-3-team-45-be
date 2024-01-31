using API.Controllers.Simulators.Models;
using API.Controllers.Simulators;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client;
using ISAProject.Modules.Company.Core.Domain;

namespace API.Controllers.Company
{
    [Route("api/contract")]
    public class ContractController : BaseApiController
    {
        private readonly IContractService _contractService;
        private readonly RabbitMqConnectionString _rabbitMqConnectionString;
        public ContractController(IContractService service, RabbitMqConnectionString rabbitMqConnectionString)
        {
            _contractService = service;
            _rabbitMqConnectionString = rabbitMqConnectionString;
        }

        [HttpPost]
        public ActionResult<HospitalContractDto> Create([FromBody] HospitalContractDto contractDto)
        {
            var result = _contractService.Create(contractDto);
            return CreateResponse(result);
        }

        [HttpPost("cancel-delivery")]
        public ActionResult CancelHospitalDelivery([FromBody] string cancelMessage)
        {
            try
            {
                var factory = _rabbitMqConnectionString.CreateFactory();
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                var messageJson = JsonConvert.SerializeObject(cancelMessage);
                var messageBytes = Encoding.UTF8.GetBytes(messageJson);

                channel.QueueDeclare(queue: "delivery-message-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.BasicPublish(exchange: "", routingKey: "delivery-message-queue", basicProperties: null, body: messageBytes);

                return Ok("Delivery message sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getAll")]
        public ActionResult<HospitalContract> GetAll()
        {
            return CreateResponse(_contractService.GetAll());
        }

    }
}
