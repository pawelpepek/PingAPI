using Microsoft.AspNetCore.Http;

namespace PingAPI.WebSocketRequests
{
    public class WebSocketRequestFactory
    {
        public IWebSocketRequest Get(HttpContext context, AppContext appContext)
        {
            switch (context.Request.Path)
            {
                case "/listen":
                    return new ListenWebSocketRequest(context, appContext);
                case "/logout":
                    return new LogoutWebSocketRequest(context, appContext);
                default:
                    return new BadWebSocketRequest(context);
            }
        }
    }
}
