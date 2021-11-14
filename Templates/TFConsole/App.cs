namespace TFConsole;

public class App
{
    private readonly ILogger<App> _logger;

    public App(ILogger<App> logger)
    {
        _logger = logger;
    }

    public Task RunAsync()
    {
        _logger.LogInformation("Hello, world!");
        return Task.CompletedTask;
    }
}