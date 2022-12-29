using Microsoft.AspNetCore.Http;

namespace PingAPI.WebSocketRequests
{
    public class WebSocketRequestFactory
    {
        public IWebSocketRequest Get(HttpContext context)
        {
            return context.Request.Path.ToString().StartsWith("/listen")
                ? new ListenWebSocketRequest(context)
                : new BadWebSocketRequest(context);
        }
    }
}
