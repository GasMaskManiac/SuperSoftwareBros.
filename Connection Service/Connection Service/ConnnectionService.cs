using System;
using System.Diagnostics;
using System.Text;
using ConnectionService.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConnectionService
{
    public class ConnnectionService
    {
        public string[] ServiceNames = { "davisonStore", "underCutters", "DodgyDealers", "BazzasBazaar", "KhansKwiki", "3Amigo" };
        public void ReceiveMessage(string sender, string message, object[] arguments)
        {
            string tempMessage = message.ToLowerInvariant();
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Queue1",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        //add all the stuff for a the body of the message and put it into a generic collection and add it here
                        var body = message; //Generic Collection
                        Debug.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: "Queue1",
                                         noAck: true,
                                         consumer: consumer);
                    switch (tempMessage)
                    {
                        case "davisonStore":
                            //Return a davisonStoreConnection
                            new DavisonService();
                            break;

                        case "underCutters":
                            //Return a underCuttersConnection
                            new CuttersService();
                            break;

                        case "DodgyDealers":
                            //Return a DodgyDealersConnection
                            new DealersService();
                            break;

                        case "BazzasBazaar":
                            //Return a BazzasBazaarConnection
                            new Connection_Service.BazzarsBazaar.StoreClient();　//アリガト、イキダキマス
                            break;

                        case "KhansKwiki":
                            //Return a KhansKwikiConnection
                            break;

                        case "3Amigo":
                            //Return a 3AmigoConnection
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An Error Was Found Causing Mischeif, Here Is The Rascal: " + ex);
            }
        }

        //public static void SendMessage(string sender, string message)
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {
        //            channel.QueueDeclare(queue: "Queue1",
        //                                 durable: false,
        //                                 exclusive: false,
        //                                 autoDelete: false,
        //                                 arguments: null);

        //            var body = Encoding.Unicode.GetBytes(message);

        //            channel.BasicPublish(exchange: "",
        //                                 routingKey: "Queue1",
        //                                 basicProperties: null,
        //                                 body: body);

        //            Debug.WriteLine(" {0} Sent {1}", message);
        //        }
        //    }

        //}
    }
}
