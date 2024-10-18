namespace WebApp.Models
{
    public class HomePageModel
    {
        public HomePageModel(IEnumerable<WeatherForecast> weatherForecasts, IEnumerable<TimeTable> timeTables)
        {
            WeatherForecasts = weatherForecasts;
            TimeTables = timeTables;
        }

       public IEnumerable<WeatherForecast> WeatherForecasts { get; }
       public IEnumerable<TimeTable> TimeTables { get; }
    }
}
