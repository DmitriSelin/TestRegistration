namespace TestRegistration.Web.Models.Dto;

public sealed class MailDto
{
    public string From { get; set; }

    public int Code { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string To { get; set; }

    public string Title { get; set; }

    public string HTML { get; set; }

    public MailDto(
        string from, int code, string host, int port,
        string login, string password, string to,
        string title, string html)
    {
        From = from;
        Code = code;
        Host = host;
        Port = port;
        Login = login;
        Password = password;
        To = to;
        Title = title;
        HTML = html;
    }
}