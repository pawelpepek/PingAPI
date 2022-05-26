using Microsoft.AspNetCore.Http;
using PingAPI.Services;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class ListenWebSocketRequest : WebSocketRequestTemplate, ISubscriber
    {
        private string _measurement=string.Empty;
        public ListenWebSocketRequest(HttpContext context, IMySingletonService mySingleton) : base(context, mySingleton)
        {
        }

        public void Update(string context)
        {
            _measurement = context;
        }

        protected override async Task Run(WebSocket webSocket)
        {
            _mySingleton.Login = true;
            _mySingleton.Subscribe(this);

            while (_mySingleton.Login)
            {
                if(_measurement!=string.Empty)
                {
                    await webSocket.SendAsync(new ArraySegment<byte>(
                        Encoding.UTF8.GetBytes(_measurement)),
                        WebSocketMessageType.Binary,
                        true,
                        System.Threading.CancellationToken.None);
                    _measurement = string.Empty;
                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}
