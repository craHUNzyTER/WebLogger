using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebLogger.Constants;
using WebLogger.Hubs;
using WebLogger.Services.Interfaces;

namespace WebLogger.Services
{
    public class SignalrLogger : ILogger
    {
        private readonly IHubContext<WebLogHub> _hubContext;

        public SignalrLogger(IHubContext<WebLogHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Write(string type, string message)
        {
            return _hubContext.Clients.Group(LoggingConstants.WebLogGroupName)
                .SendAsync(LoggingConstants.WebLogConsumeMethodName, type, message);
        }
    }
}