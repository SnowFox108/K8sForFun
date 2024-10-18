using WebApp.Models;

namespace WebApp.Services;

public class FrontApiService : IFrontApiService
{
    private readonly HttpClient _client;
    public FrontApiService(HttpClient client)
    {
        _client = client;
    }
    public async Task<IEnumerable<WeatherForecast>> GetAll()
    {
        HttpResponseMessage response = await _client.GetAsync("weatherforecast");
        response.EnsureSuccessStatusCode();
        var weatherForecasts = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
        return weatherForecasts ?? new List<WeatherForecast>();
    }
}

