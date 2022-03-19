#Car Dealer 

Приложението Car Dealer представлява MVC проект, който съхранява коли и информация за тях. Информацията се пази в база данни. Приложението има два интерфейса – Конзолен и Уеб. И двата позволяват добавяне на нов екземпляр в базата данни, редактиране на информацията и изтриване на екземпляр. Също така, има възможност за търсене на определен запис по име на марката или модела. Друга опция на приложението е визуализиране на колите.
Приложението е създадено по модела Database – First, като това означава, че първо е направена базата данни, а след това класовете и връзките към нея. За улеснение на входа и изхода на данните, са създадени класове за визуализация и един клас за вкарване на информация. Класовете за визуализация(Output Models) са  съответно за извеждане на съкратена информация и за по-подробна такава. Класът за въвеждане на информация (Input Model) позволява вкарване на информация, като зададените атрибути на всяко свойство на класа помагат за валидацията на въвежданите данни в Уеб частта. За да се осъществят CRUD операциите с базата данни, съществуват клас Repository, където са методите за достъпа до базата и клас Service, който съдържа методите за работа в приложениeто.



