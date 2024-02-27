namespace TestRegistration.Web.Infrastructure;

public class MailSettings
{
    internal const string SectionName = "MailSettings";

    public string From { get; set; } = null!;

    public string Host { get; set; } = null!;

    public int Port { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    protected MailSettings(string from, string host, int port, string login, string password)
    {
        From = from;
        Host = host;
        Port = port;
        Login = login;
        Password = password;
    }

    public MailSettings() { }
}