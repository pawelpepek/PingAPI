using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class LogoutWebSocketRequest : WebSocketRequestTemplate
    {
        public LogoutWebSocketRequest(HttpContext context) : base(context) { }
        protected override async Task Run(WebSocket webSocket)
        {
            var splittedPath = _context.Request.Path.ToString().Split("/");
            if (splittedPath.Length > 2)
            {
                var token = splittedPath[2];
                _appService.Logout(token);

                await Task.Run(() => { });
            }
        }
    }
}
