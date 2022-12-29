using Microsoft.AspNetCore.Http;
using PingAPI.Services;

namespace PingAPI.WebSocketRequests
{
    public class WebSocketRequestFactory
    {
        public IWebSocketRequest Get(HttpContext context, IAppService appContext)
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
