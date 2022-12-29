using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public abstract class WebSocketRequestTemplate : IWebSocketRequest
    {
        protected readonly HttpContext _context;

        public WebSocketRequestTemplate(HttpContext context)
        {
            _context = context;
        }
        protected abstract Task Run(WebSocket webSocket);
        public async Task Create()
        {
            using WebSocket webSocket = await _context.WebSockets.AcceptWebSocketAsync();
            await Run(webSocket);
            await CloseSocket(webSocket);
        }
        protected async Task CloseSocket(WebSocket webSocket)
        {
            await webSocket.CloseAsync(
                WebSocketCloseStatus.NormalClosure, 
                "Closed", 
                System.Threading.CancellationToken.None);
        }
    }
}
