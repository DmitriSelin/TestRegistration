using System.Text;

namespace TestRegistration.EmailServer.Infrastructure;

internal sealed class StartSettings
{
    internal static void Start()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        var now = DateTime.Now;
        Console.WriteLine($"Сервер отправки писем запущен - {now.Date} - {TimeZoneInfo.Local.DisplayName}");
    }
}