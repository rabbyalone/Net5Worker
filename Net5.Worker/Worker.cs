using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Net5.Worker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Net5.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICountryService _country;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, ICountryService countryService, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _country = countryService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using(var scope = _serviceProvider.CreateScope()){
                    _country.FetchAllCountries();
                }
                
                await Task.Delay(1000, stoppingToken);

                
            }

        }
    }
}
