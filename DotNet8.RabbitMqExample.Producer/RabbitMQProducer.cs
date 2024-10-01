namespace DotNet8.RabbitMqExample.Producer;

public class RabbitMQProducer : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        var routingKey = "data";

        channel.QueueDeclare(
            queue: routingKey,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        channel.BasicPublish(exchange: "", routingKey: routingKey, body: body);
    }
}