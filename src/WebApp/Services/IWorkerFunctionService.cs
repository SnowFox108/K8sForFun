using WebApp.Models;

namespace WebApp.Services
{
    public interface IWorkerFunctionService
    {
        Task<IEnumerable<TimeTable>> GetAll();
    }
}
