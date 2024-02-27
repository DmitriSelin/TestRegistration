using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestRegistration.EmailServer.Infrastructure;
using TestRegistration.EmailServer.Services;
using TestRegistration.EmailServer.Services.Interfaces;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IConnectionService, ConnectionService>();
    })
    .Build();

StartSettings.Start();
var connectionService = host.Services.GetRequiredService<IConnectionService>();
Console.WriteLine("Для закрытия приложения нажмите Enter");
connectionService.Connect();