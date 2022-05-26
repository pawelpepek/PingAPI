using Microsoft.Extensions.Hosting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingAPI.Services
{
    public class MyHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var message = await new PingExample().RunPing();
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

