using ClassLibrary.Models;

using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ClassLibrary.Extensions;
public class MessageProducer : IMessageProducer
{
    public void SendMessage(ProductsCodesModel message)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare("productsIngress", durable: true, exclusive: false);
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);
        channel.BasicPublish(exchange: "", routingKey: "productsIngress", body: body);
    }
}
public interface IMessageProducer
{
    void SendMessage(ProductsCodesModel message);
}