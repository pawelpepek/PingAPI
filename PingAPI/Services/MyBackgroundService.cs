using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PingAPI.Services
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly IMySingletonService _mySingletonService;

        public MyBackgroundService(IMySingletonService mySingletonService)
        {
            _mySingletonService = mySingletonService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if(_mySingletonService.Login)
                {
                    var message = await new PingExample().RunPing();
                    Console.WriteLine(message);
                    _mySingletonService.Notify(message);
                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}
