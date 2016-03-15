using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;

namespace ConnectionService.MessageHandling
{
    class Send
    {
        public static void Main(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Queue1",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.Unicode.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "Queue1",
                                         basicProperties: null,
                                         body: body);

                    Debug.WriteLine(" [x] Sent {0}", message);
                }
            }

        }
    }
}
