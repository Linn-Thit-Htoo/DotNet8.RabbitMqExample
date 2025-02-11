﻿var factory = new ConnectionFactory { HostName = "localhost" };
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

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};

channel.BasicConsume(queue: routingKey, autoAck: true, consumer: consumer);
Console.ReadKey();
