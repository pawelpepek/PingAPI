using System.Collections.Generic;

namespace PingAPI.Services
{
    public class MySingletonService:IMySingletonService
    {
        public bool Login { get; set; }

        private readonly List<ISubscriber> _subscribers = new();


        public void Subscribe(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void UnSubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(string context)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(context);
            }
        }
    }
}
