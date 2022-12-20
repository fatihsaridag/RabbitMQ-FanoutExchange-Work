using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace RabbitmqFirstProject.publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            //RabbitMq ya bağlanmamız için connection factory isminde bir nesne örneğği alalım
            var factory = new ConnectionFactory();
            //Uri yımızı belirticez. CloudAmqp deki instancedan urli alıyoruz. Gerçek seneryoda bunları appsetting.json içeçrisinde tutuyoruz.
            factory.Uri = new Uri("amqps://eznbdupx:Qf4h0Avxf0yEipy5VaR1D7UHRfIL0Gfn@gerbil.rmq.cloudamqp.com/eznbdupx");

            //factory üzerinden bir bağlantı açıyoruz.
            using var connection = factory.CreateConnection();
            //Artık bir bağlantımız var ve bu bağlantı  üzerinden kanal oluşturuyoruz onun üzerinden bağlanıcaz.
            var channel = connection.CreateModel(); //Bu kanal üzerinden rabbitMq ile haberleşebiliriz.
            //1.param : Exchange ismi , 2.param : restart atınca uygulama fiziksel olarak kaydedilsin , 3.param : Exchange tipi ? 
            channel.ExchangeDeclare("logs-fanout",durable:true, type:ExchangeType.Fanout);                                                        
           
            Enumerable.Range(1, 50).ToList().ForEach(x =>
             {
                 string log = $"log {x}"; // Byte çevirip istediğimiz formatı gönderebiliriz.
                var messageBody = Encoding.UTF8.GetBytes(log);
                 channel.BasicPublish("logs-fanout", "", null, messageBody);  
                Console.WriteLine($"Mesaj Gönderilmiştir : {log}");
             });

           
               
        }
    }
}
