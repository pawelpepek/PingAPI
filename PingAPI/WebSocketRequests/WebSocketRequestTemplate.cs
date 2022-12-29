using Microsoft.AspNetCore.Http;
using PingAPI.Services;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public abstract class WebSocketRequestTemplate : IWebSocketRequest
    {
        protected readonly HttpContext _context;
        protected readonly IAppService _appService;

        public WebSocketRequestTemplate(HttpContext context)
        {
            _context = context;
            _appService = _context.RequestServices.GetService(typeof(IAppService)) as IAppService;
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
