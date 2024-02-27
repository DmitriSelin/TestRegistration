using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TestRegistration.Web.Infrastructure;
using TestRegistration.Web.Services.Interfaces;

namespace TestRegistration.Web.Services;

public sealed class MessageProducer : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(QueueConstants.Name, false, false, false, null);

        string jsonMessage = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonMessage);

        channel.BasicPublish("", QueueConstants.Name, false, null, body);
    }
}