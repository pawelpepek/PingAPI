using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class LogoutWebSocketRequest : WebSocketRequestTemplate
    {
        public LogoutWebSocketRequest(HttpContext context, AppContext appContext) : base(context, appContext)
        {
        }

        protected override async Task Run(WebSocket webSocket)
        {
            _appContext.Login = false;
            await Task.Run(() => { });
        }
    }
}
