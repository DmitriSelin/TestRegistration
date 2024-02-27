namespace TestRegistration.Web.Services.Interfaces;

public interface IMessageProducer
{
    void SendMessage<T>(T message);
}