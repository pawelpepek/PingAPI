﻿using Microsoft.AspNetCore.Http;
using PingAPI.Services;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public abstract class WebSocketRequestTemplate : IWebSocketRequest
    {
        protected readonly HttpContext _context;
        protected readonly IAppService _appContext;

        public WebSocketRequestTemplate(HttpContext context, IAppService appContext)
        {
            _context = context;
            _appContext = appContext;
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
