using System.Threading.Tasks;

namespace WebLogger.Services.Interfaces
{
    public interface ILogger
    {
        Task Write(string type, string message);
    }
}