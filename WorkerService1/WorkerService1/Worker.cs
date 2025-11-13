namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            long i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                i++;
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Counter: {count} | Worker running at: {time}", i, DateTimeOffset.Now);
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
            }
        }
    }
}
