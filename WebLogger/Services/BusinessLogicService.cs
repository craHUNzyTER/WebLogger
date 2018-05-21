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
            var isError = true;
            while (true)
            {
                string type;
                string details;

                if (isError)
                {
                    type = "Error";
                    details = "Some important error.";

                    isError = false;
                }
                else
                {
                    type = "Warning";
                    details = "Some information.";

                    isError = true;
                }

                _logger.Write(type, details);
                Thread.Sleep(1000);
            }
        }
    }
}