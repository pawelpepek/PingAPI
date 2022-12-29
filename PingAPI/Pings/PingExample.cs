using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingAPI.Pings
{
    public class PingExample
    {
        private readonly string _who = "graniowki.web.app";

        private string _message = "";

        public PingExample(){}

        public async Task<string> RunPing()
        {
            var waiter = new AutoResetEvent(false);

            var pingSender = new Ping();

            pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            var data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var buffer = Encoding.ASCII.GetBytes(data);

            var timeout = 12000;

            var options = new PingOptions(64, true);

            pingSender.SendAsync(_who, timeout, buffer, options, waiter);

            var random = new Random();

            while (_message == string.Empty)
            {
                await Task.Delay(random.Next(10, 100));
            }
            return _message;
        }


        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ((AutoResetEvent)e.UserState).Set();
            }

            if (e.Error != null)
            {
                ((AutoResetEvent)e.UserState).Set();
            }

            PingReply reply = e.Reply;

            DisplayReply(reply);

            ((AutoResetEvent)e.UserState).Set();
        }

        public void DisplayReply(PingReply reply)
        {
            if (reply == null)
                return;

            _message = reply.Status.ToString();
            if (reply.Status == IPStatus.Success)
            {
                _message += $" - RoundTrip time: {reply.RoundtripTime}";
            }
        }

    }
}
