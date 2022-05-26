using Microsoft.AspNetCore.Http;
using PingAPI.Services;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class LogoutWebSocketRequest : WebSocketRequestTemplate
    {
        public LogoutWebSocketRequest(HttpContext context, IMySingletonService mySingleton) : base(context, mySingleton)
        {
        }

        protected override async Task Run(WebSocket webSocket)
        {
            _mySingleton.Login = false;
            await Task.Run(() => { });
        }
    }
}
