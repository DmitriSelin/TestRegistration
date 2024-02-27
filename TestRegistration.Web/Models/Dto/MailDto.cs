using TestRegistration.Web.Infrastructure;

namespace TestRegistration.Web.Models.Dto;

public sealed class MailDto : MailSettings
{
    public string To { get; init; }

    public int Code { get; init; }

    public string Title { get; init; }

    public string HTML { get; init; }

    public MailDto(
        string from, string host, int port,
        string login, string password, string to, int code,
        string title, string html) : base(from, host, port, login, password)
    {
        To = to;
        Code = code;
        Title = title;
        HTML = html;
    }
}