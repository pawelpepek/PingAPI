namespace PingAPI.Services
{
    public interface IAppService
    {
        bool IsLogged(string token);
        void Logout(string token);
        string Login();
    }
}