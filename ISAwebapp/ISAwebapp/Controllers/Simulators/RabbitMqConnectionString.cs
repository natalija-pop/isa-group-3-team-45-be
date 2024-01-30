using RabbitMQ.Client;
namespace API.Controllers.Simulators
{
    public class RabbitMqConnectionString
    {
        private readonly string _rabbitMqHost = "localhost"; 
        private readonly int _rabbitMqPort = 5672; 
        private readonly string _rabbitMqUserName = "natalija"; 
        private readonly string _rabbitMqPassword = "natalija123"; 
        private readonly string _rabbitMqVirtualHost = "ISA simulator";

        public ConnectionFactory CreateFactory()
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMqHost,
                Port = _rabbitMqPort,
                UserName = _rabbitMqUserName,
                Password = _rabbitMqPassword,
                VirtualHost = _rabbitMqVirtualHost
            };
            return factory;
        }
    }
}