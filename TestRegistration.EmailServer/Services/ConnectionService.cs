using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text.Json;
using TestRegistration.EmailServer.Services.Interfaces;
using System.Text;
using TestRegistration.Web.Models.Dto;

namespace TestRegistration.EmailServer.Services;

public class ConnectionService : IConnectionService
{
    private const string queueName = "Mails";
    private readonly IMailService _mailService;

    public ConnectionService(IMailService mailService)
    {
        _mailService = mailService;
    }

    public void Connect()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queueName, false, false, false, null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, eventArgs) =>
        {
            byte[] body = eventArgs.Body.ToArray();
            var jsonMessage = Encoding.UTF8.GetString(body);

            try
            {
                ReceiveMessage(jsonMessage);
            }
            catch (Exception ex)
            {
                var now = DateTime.Now;
                Console.WriteLine($"Исключение: {ex.Message} произошло {now.Date} в {now.TimeOfDay} по {TimeZoneInfo.Local.DisplayName}");
            }
        };

        channel.BasicConsume(queueName, true, consumer);
        Console.ReadLine();
    }

    private void ReceiveMessage(string jsonMessage)
    {
        MailDto mail = JsonSerializer.Deserialize<MailDto>(jsonMessage)!;
        var now = DateTime.Now;
        _mailService.SendMessage(mail);
        Console.WriteLine($"{now.Date} {now.TimeOfDay} {mail!.To} код: {mail!.Code}");
    }
}
