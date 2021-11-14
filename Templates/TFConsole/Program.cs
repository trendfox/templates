using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddCommandLine(args)
    .Build();

var services = new ServiceCollection()
    .AddAppLogging(config)
    .AddAppServices();

using var provider = services
    .BuildServiceProvider();

var app = provider
    .GetRequiredService<App>();

await app.RunAsync();
