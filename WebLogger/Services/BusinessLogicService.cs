using System.Threading;
using WebLogger.Services.Interfaces;

namespace WebLogger.Services
{
    /// <summary>
    /// Fake service that constantly generates logs
    /// </summary>
    public class BusinessLogicService : IBusinessLogicService
    {
        private readonly ILogger _logger;

        public BusinessLogicService(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomeLogic()
        {
            while (true)
            {
                _logger.Write("Error", "Some important error.");
                Thread.Sleep(1000);
            }
        }
    }
}