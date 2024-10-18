using WebApp.Models;

namespace WebApp.Services
{
    public class WorkerFunctionService : IWorkerFunctionService
    {

        private readonly HttpClient _client;

        public WorkerFunctionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<TimeTable>> GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync("api/TrainTimeTable");
            response.EnsureSuccessStatusCode();
            var weatherForecasts = await response.Content.ReadFromJsonAsync<List<TimeTable>>();
            return weatherForecasts ?? new List<TimeTable>();
        }

    }
}
