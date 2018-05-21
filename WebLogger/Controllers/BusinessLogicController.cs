using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLogger.Services.Interfaces;

namespace WebLogger.Controllers
{
    public class BusinessLogicController : Controller
    {
        private readonly IBusinessLogicService _businessLogicService;

        public BusinessLogicController(IBusinessLogicService businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }

        [HttpPost("api/v1/start-log")]
        public IActionResult UpdateLogging()
        {
            Task.Run(() => _businessLogicService.DoSomeLogic());
            return NoContent();
        }
    }
}