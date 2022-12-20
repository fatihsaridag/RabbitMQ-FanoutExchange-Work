using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitmqFirstProject.subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var factory = new ConnectionFactory(); 
            factory.Uri = new Uri("amqps://eznbdupx:Qf4h0Avxf0yEipy5VaR1D7UHRfIL0Gfn@gerbil.rmq.cloudamqp.com/eznbdupx");  
            using var connection = factory.CreateConnection(); 
            var channel = connection.CreateModel();


            //Kuyruk oluşturucaz ve bu kuyrugun kendisine ait Instance'ı olsun bu yüzden random bir kuyruk oluşturuyoruz.
            var randomQueue = channel.QueueDeclare().QueueName;                  //Bu bize random bir kuruk ismi veriyor.

            channel.QueueBind(randomQueue, "logs-fanout", "", null);              //QueBind ile beraber uygulama her ayağa kalktığında bir kuyruk oluşacak ve uygulama down olunca kuyruk silinecek.
                                                                                 //Eğer QueueDeclare deseydik ilgili subscriber kapansa bile kuyruk durur (Yanlış kullanım bu seneryoda)




            channel.BasicQos(0, 1, false);                                       // Birer birer alsın diyoruz.  
            var consumer = new EventingBasicConsumer(channel);        
            channel.BasicConsume(randomQueue, false,consumer);                   // Yukarıdaki random kuyruk ismini tüketmesini istiyoruz
            Console.WriteLine("Loglar dinleniyor..");                            // Bu yazıyı almaya çalışalım.
            consumer.Received += (object sender, BasicDeliverEventArgs e) => {  
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Thread.Sleep(1500);   
                Console.WriteLine("Gelen mesaj : " + message);

                channel.BasicAck(e.DeliveryTag, false); 
            };
            Console.ReadLine();
        }
    }
}
