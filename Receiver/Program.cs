using ClassLibrary.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();
        var connection = CreateRabbitMQConnection();

        using (var channel = connection.CreateModel())
        {
            DeclareQueue(channel);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = SetupRabbitMQConsumer(channel, serviceProvider);
            channel.BasicConsume(queue: "productsIngress", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        return services.BuildServiceProvider();
    }

    private static IConnection CreateRabbitMQConnection()
    {
        var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
        return factory.CreateConnection();
    }

    private static void DeclareQueue(IModel channel)
    {
        channel.QueueDeclare(queue: "productsIngress", durable: true, exclusive: false);
    }

    private static EventingBasicConsumer SetupRabbitMQConsumer(IModel channel, IServiceProvider serviceProvider)
    {
        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);


            Console.WriteLine($" [x] Received {message}");
        };

        return consumer;
    }
}
