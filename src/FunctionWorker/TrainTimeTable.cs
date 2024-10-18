using FunctionWorker.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionWorker
{
    public class TrainTimeTable
    {
        private readonly ILogger<TrainTimeTable> _logger;
        private static readonly string[] Trains = new[]
        {
            "London", "Reading", "Bath", "Coventry", "Blackwater", "Richmond", "Airport", "Heathrow", "Gatwick", "Home"
        };

        public TrainTimeTable(ILogger<TrainTimeTable> logger)
        {
            _logger = logger;
        }

        [Function("TrainTimeTable")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var result = Enumerable.Range(1, 5).Select(index => new TimeTable
                {
                    Date = DateTime.Now.AddDays(index),
                    Name = Trains[Random.Shared.Next(Trains.Length)]
                })
                .ToArray();

            return new JsonResult(result);
        }
    }
}
