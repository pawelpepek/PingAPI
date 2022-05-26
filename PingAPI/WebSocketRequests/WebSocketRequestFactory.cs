using Microsoft.AspNetCore.Http;
using PingAPI.Services;

namespace PingAPI.WebSocketRequests
{
    public class WebSocketRequestFactory
    {
        private readonly IMySingletonService _mySingleton;

        public WebSocketRequestFactory(IMySingletonService mySingleton)
        {
            _mySingleton = mySingleton;
        }
        public IWebSocketRequest Get(HttpContext context)
        {
            switch (context.Request.Path)
            {
                case "/listen":
                    return new ListenWebSocketRequest(context, _mySingleton);
                case "/logout":
                    return new LogoutWebSocketRequest(context, _mySingleton);
                default:
                    return new BadWebSocketRequest(context);
            }
        }
    }
}
