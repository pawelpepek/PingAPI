using System.Collections.Generic;
using System;

namespace PingAPI.Services
{
    public class AppService : IAppService
    {
        private readonly List<string> _tokens = new();

        public bool IsLogged(string token) => _tokens.Contains(token);
        public void Logout(string token) => _tokens.Remove(token);
        public string Login()
        {
            var token = Guid.NewGuid().ToString();
            _tokens.Add(token);
            return token;
        }
    }
}
