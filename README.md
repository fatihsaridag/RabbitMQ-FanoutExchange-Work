## Fanout Exchang'in yapmış oldugu işlem ##

Producer(Publisher) , RabbitMQ ya mesaj gönderdiğinde Exchange'i fanout olana bir mesaj gönderir. FanoutExchange ise herhangi bir filtre yapmadan kendisine bağlı olan tüm kuyruklara  aynı mesajı iletir. Daha sonra bu kuyrukları dinleyen cunsomerlar ise mesajları okur. Cunsomerların mesajları okuyabilmesi için mutlaka bir kuyruk olması gerekmektedir. 


## Gerçek Uygulama olarak düşünelim ? ##
Bir uygulama yaptık ve saat başı hava tahmini görmek istiyoruz. 
1. Producer : AspNet Core Uygulaması düşünelim
2. Producer bu hava tahmin durumunu alıyor ve Fanout Exchange'e yolluyor. Bağlı olan hiç kuyruk yok ise tüm mesajlar boşa gider.
3. Daha sonra arkadaşlarımıza dedik ki biz böyle bir uygulama yaptık isterseniz Fanout Exchange'e bir kuyruk oluşturup bağlanabilirsiniz .
4. Arkadaşlar da kendi projelerini yaptılar kimisi python kimi java kimi dotnet .
5. Hemen bu arkadaşlar kuyruk oluşturdu fanout exchange'e bağlandı. Fanout exchange'e bağlı olan kuyruğa mesajlar gönderildi ve kuyruktan da cunsomerlar mesajları aldı
6. Sonuç olarak : Cunsomerlar kuyrukları oluşturdular çünkü eğer biz oluşturursak kaç tane cunsomerın bağlanacağını bilmiyoruz. 
7. Seneryo Özeti : Ben mesajımı oluşturuyorum(publisher) eğer sen mesajı almak istersen kuyrugunu kendin oluştur.
8. Mesela arkadaşım kuyruga bağlandı(cunsomer) ve 1 hafta sonra bağlanmak istemiyor o zaman kuyrugunu kapatıp gidebilir.
![1](https://user-images.githubusercontent.com/68101192/208610993-d479e1bd-7630-4103-89b1-039ceb87e4ef.PNG)

## Fanout Exchange Çalışması ##


![1](https://user-images.githubusercontent.com/68101192/208630621-7e02e322-05f9-45f4-8082-ce543cba9973.png)
![2](https://user-images.githubusercontent.com/68101192/208630625-c567ee38-4472-40b5-bb94-0a0e6cde02eb.png)
![3](https://user-images.githubusercontent.com/68101192/208630627-941d5402-8168-4d81-8209-dc3fdc718267.png)
![4](https://user-images.githubusercontent.com/68101192/208630610-309bd2ac-0aea-4fb7-9218-ba97fe6b3fe9.png)

