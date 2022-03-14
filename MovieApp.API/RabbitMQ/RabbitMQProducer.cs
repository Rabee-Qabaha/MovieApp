using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MovieApp.API.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("RabbitMQTesting", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange:"",routingKey: "RabbitMQTesting", body:body);
        }
    }
}
