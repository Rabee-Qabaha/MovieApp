// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


var factory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("RabbitMQTesting", exclusive: false);


var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);


    Console.WriteLine($"A changes happened to this movie check the details : {message}");
};

channel.BasicConsume(queue:"RabbitMQTesting",autoAck:true,consumer:consumer);

Console.ReadKey();