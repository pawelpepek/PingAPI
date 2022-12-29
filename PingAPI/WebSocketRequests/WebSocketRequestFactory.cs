using Microsoft.AspNetCore.Http;

namespace PingAPI.WebSocketRequests
{
    public class WebSocketRequestFactory
    {
        public IWebSocketRequest Get(HttpContext context)
        {
            if (context.Request.Path.ToString().StartsWith("/logout/"))
            {
                return new LogoutWebSocketRequest(context);
            }

            return context.Request.Path.ToString() switch
            {
                "/listen" => new ListenWebSocketRequest(context),
                _ => new BadWebSocketRequest(context),
            };
        }
    }
}
