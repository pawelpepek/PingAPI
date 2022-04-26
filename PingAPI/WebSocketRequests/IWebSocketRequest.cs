using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public interface IWebSocketRequest
    {
        Task Create();
    }
}
