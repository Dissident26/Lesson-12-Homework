using MyClassLib;

var NewsAgency = new NewsProvider();

NewsAgency.AddNews(new[]{
    new News(NewsCategories.Accidents, "Accident #1"),
    new News(NewsCategories.Accidents, "Accident #2"),
    new News(NewsCategories.Accidents, "Accident #3"),
    new News(NewsCategories.Sports, "Sport #1"),
    new News(NewsCategories.Sports, "Sport #2"),
    new News(NewsCategories.Sports, "Sport #3"),
    new News(NewsCategories.Weather, "Weather #1"),
    new News(NewsCategories.Weather, "Weather #2"),
    new News(NewsCategories.Weather, "Weather #3"),
    new News(NewsCategories.Humour, "Humour #1"),
    new News(NewsCategories.Humour, "Humour #2"),
    new News(NewsCategories.Humour, "Humour #3"),
    new News(NewsCategories.News, "News #1"),
    new News(NewsCategories.News, "News #2"),
    new News(NewsCategories.News, "News #3"),
});

var client1 = new Client();
var client2 = new Client();
var client3 = new Client();
var client4 = new Client();
var client5 = new Client();
var client6 = new Client();

client1.AddCategory(new[] { NewsCategories.News, NewsCategories.Humour });
client2.AddCategory(new[] { NewsCategories.Sports, NewsCategories.Weather });
client3.AddCategory(new[] { NewsCategories.Accidents, NewsCategories.Humour });
client4.AddCategory(new[] { NewsCategories.Sports, NewsCategories.Accidents });
client5.AddCategory(new[] { NewsCategories.News, NewsCategories.Weather });
client6.AddCategory(new[] { NewsCategories.Humour, NewsCategories.Weather });

NewsAgency.AddConsumer(client1);
NewsAgency.AddConsumer(client2);
NewsAgency.AddConsumer(client3);
NewsAgency.AddConsumer(client4);
NewsAgency.AddConsumer(client5);
NewsAgency.AddConsumer(client6);

NewsAgency.SendNews();