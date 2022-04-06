namespace MyClassLib
{
    public class NewsProvider
    {
        List<News> News = new();

        public delegate void SendNewsHandler(string message);

        event SendNewsHandler? NotifyNewsConsumers;
        event SendNewsHandler? NotifyWeatherConsumers;
        event SendNewsHandler? NotifySportsConsumers;
        event SendNewsHandler? NotifyAccidentsConsumers;
        event SendNewsHandler? NotifyHumourConsumers;

        public void AddNews(NewsCategories category, string message)
        {
            News.Add(new News(category, message));
        }

        public void AddNews(News[] news)
        {
            foreach (var item in news)
            {
                News.Add(new News(item.Category, item.Message));
            }
        }

        public void AddConsumer(Client client)
        {
            var clientsCategories = client.GetCategoriesList();
            clientsCategories.ForEach(category =>
            {
                switch (category)   //так и не понял почему тут GetCategoryDelegate(category) не работает как надо
                {
                    case NewsCategories.News:
                        NotifyNewsConsumers += client.Subscribe;
                        break;
                    case NewsCategories.Weather:
                        NotifyWeatherConsumers += client.Subscribe;
                        break;
                    case NewsCategories.Sports:
                        NotifySportsConsumers += client.Subscribe;
                        break;
                    case NewsCategories.Accidents:
                        NotifyAccidentsConsumers += client.Subscribe;
                        break;
                    case NewsCategories.Humour:
                        NotifyHumourConsumers += client.Subscribe;
                        break;
                    default:
                        throw new Exception("Category Not Found!");
                }
            });
        }

        public void SendNews()  //тем не менее тут работает отлично
        {
            News.ForEach(news =>
            {
                var CategoryDelegate = GetCategoryDelegate(news.Category);
                CategoryDelegate?.Invoke(news.Message);
            });
        }

        private SendNewsHandler? GetCategoryDelegate(NewsCategories category)
        {
            switch (category)
            {
                case NewsCategories.News:
                    return NotifyNewsConsumers;
                case NewsCategories.Weather:
                    return NotifyWeatherConsumers;
                case NewsCategories.Sports:
                    return NotifySportsConsumers;
                case NewsCategories.Accidents:
                    return NotifyAccidentsConsumers;
                case NewsCategories.Humour:
                    return NotifyHumourConsumers;
                default:
                    throw new Exception("Category Not Found!");
            }
        }
    }

    public class Client
    {
        List<NewsCategories> Categories = new();
        public void AddCategory(NewsCategories category)
        {
            if (!Categories.Contains(category))
            {
                Categories.Add(category);
            }
        }

        public void AddCategory(NewsCategories[] categories)
        {
            foreach (var category in categories)
            {
                if (!Categories.Contains(category))
                {
                    Categories.Add(category);
                }
            }
        }

        public void RemoveCategory(NewsCategories category)
        {
            if (Categories.Contains(category))
            {
                Categories.Remove(category);
            }
        }

        public List<NewsCategories> GetCategoriesList()
        {
            return Categories;
        }

        public void Subscribe(string message)
        {
            Console.WriteLine(message);
        }
    }

    public enum NewsCategories
    {
        News,
        Weather,
        Sports,
        Accidents,
        Humour,
    }

    public class News
    {
        public NewsCategories Category;
        public string Message = string.Empty;
        public News(NewsCategories category, string message)
        {
            Category = category;
            Message = message;
        }
    }
}