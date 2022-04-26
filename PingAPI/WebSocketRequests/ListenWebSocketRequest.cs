using Microsoft.AspNetCore.Http;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class ListenWebSocketRequest : WebSocketRequestTemplate
    {
        public ListenWebSocketRequest(HttpContext context, AppContext appContext) : base(context, appContext)
        {
        }

        protected override async Task Run(WebSocket webSocket)
        {
            _appContext.Login = true;

            while (_appContext.Login)
            {
                await SendPingTest(webSocket);
            }
        }
        private async Task SendPingTest(WebSocket webSocket)
        {
            var message = await new PingExample().RunPing();

            await webSocket.SendAsync(new ArraySegment<byte>(
                Encoding.UTF8.GetBytes(message)),
                WebSocketMessageType.Binary,
                true,
                System.Threading.CancellationToken.None);
        }
    }
}
