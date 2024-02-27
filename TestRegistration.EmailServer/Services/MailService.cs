using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using TestRegistration.EmailServer.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using TestRegistration.Web.Models.Dto;

namespace TestRegistration.EmailServer.Services;

public sealed class MailService : IMailService
{
    public void SendMessage(MailDto mailDto)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(mailDto.From));
        email.To.Add(MailboxAddress.Parse(mailDto.To));
        email.Subject = mailDto.Title;
        email.Body = new TextPart(TextFormat.Html) { Text = mailDto.HTML };

        using var client = new SmtpClient();
        client.Connect(mailDto.Host, mailDto.Port, SecureSocketOptions.StartTls);
        client.Authenticate(mailDto.Login, mailDto.Password);
        client.Send(email);
        client.Disconnect(true);
    }
}