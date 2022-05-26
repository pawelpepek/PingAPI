namespace PingAPI.Services
{
    public interface IMySingletonService
    {
        public bool Login { get; set; }

        public void Subscribe(ISubscriber subscriber);
        public void UnSubscribe(ISubscriber subscriber);
        void Notify(string context);
    }
}
