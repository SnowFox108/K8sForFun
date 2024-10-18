using WebApp.Models;

namespace WebApp.Services;

public interface IFrontApiService
{
    Task<IEnumerable<WeatherForecast>> GetAll();
}

