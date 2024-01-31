using API.Controllers.Simulators.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using IModel = RabbitMQ.Client.IModel;

namespace API.Controllers.Simulators.QueueParticipants
{
    public class HospitalQueueProducer
    {
        public static void SendDeliveryMessage(IModel channel)
        {
            channel.QueueDeclare("delivery-message-queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var message = "The delivery has started";
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "delivery-message-queue", null, body);
        }
    }
}
