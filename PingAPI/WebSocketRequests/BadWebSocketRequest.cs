using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace PingAPI.WebSocketRequests
{
    public class BadWebSocketRequest : IWebSocketRequest
    {
        private readonly HttpContext _context;
        public BadWebSocketRequest(HttpContext context)
        {
            _context = context;
        }
        public async Task Create()
        {
            _context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await Task.Delay(1);
        }
    }
}
