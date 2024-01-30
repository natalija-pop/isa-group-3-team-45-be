using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using API.Controllers.Simulators.Models;
using IModel = RabbitMQ.Client.IModel;

namespace API.Controllers.Simulators.QueueParticipants
{
    public static class QueueConsumer
    {
        public static void StopSimulation(IModel channel)
        {
            channel.QueueDeclare("stop-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
            };

            channel.BasicConsume("stop-queue", true, consumer);
        }

        public static void ReceiveNewPosition(IModel channel)
        {
            channel.QueueDeclare("position-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var messageJson = Encoding.UTF8.GetString(body);
                var currentPosition = Newtonsoft.Json.JsonConvert.DeserializeObject<Position>(messageJson);
            };

            channel.BasicConsume("position-queue", true, consumer);
        }
    }
}