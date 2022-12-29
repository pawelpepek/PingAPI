using Microsoft.AspNetCore.Http;
using PingAPI.Pings;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class ListenWebSocketRequest : WebSocketRequestTemplate
    {
        public ListenWebSocketRequest(HttpContext context) : base(context){}

        protected override async Task Run(WebSocket webSocket)
        {
            while (webSocket.State== WebSocketState.Open)
            {
                await SendPingTest(webSocket);
            }
        }

        private static async Task SendPingTest(WebSocket webSocket)
        {
            var message = await new PingExample().RunPing();
            await SendMessage(webSocket, message);
        }

        private static async Task SendMessage(WebSocket webSocket, string message)
        {
            await webSocket.SendAsync(new ArraySegment<byte>(
                Encoding.UTF8.GetBytes(message)),
                WebSocketMessageType.Binary,
                true,
                System.Threading.CancellationToken.None);
        }
    }
}
