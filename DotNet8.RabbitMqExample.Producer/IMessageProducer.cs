namespace DotNet8.RabbitMqExample.Producer;

public interface IMessageProducer
{
    void SendMessage<T>(T message);
}
