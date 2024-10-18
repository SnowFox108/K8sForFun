using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFrontApiService _frontApiService;
        private readonly IWorkerFunctionService _workerFunctionService;

        public HomeController(ILogger<HomeController> logger, IFrontApiService frontApiService, IWorkerFunctionService workerFunctionService)
        {
            _logger = logger;
            _frontApiService = frontApiService;
            _workerFunctionService = workerFunctionService;
        }

        public async Task<IActionResult> Index()
        {
            var weatherForecasts = await _frontApiService.GetAll();
            var timeTables = await _workerFunctionService.GetAll();
            return View(new HomePageModel(weatherForecasts, timeTables));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
