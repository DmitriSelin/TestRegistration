using Microsoft.Extensions.Options;
using TestRegistration.Web.Data;
using TestRegistration.Web.Exceptions;
using TestRegistration.Web.Infrastructure;
using TestRegistration.Web.Models;
using TestRegistration.Web.Models.Dto;
using TestRegistration.Web.Requests;
using TestRegistration.Web.Services.Interfaces;

namespace TestRegistration.Web.Services;

public sealed class AuthenticationService : IAuthService
{
    private readonly IMessageProducer _messageProducer;
    private readonly MailSettings _mailSettings;

    public AuthenticationService(
        IMessageProducer messageProducer,
        IOptions<MailSettings> mailSettings)
    {
        _messageProducer = messageProducer;
        _mailSettings = mailSettings.Value;
    }

    public async Task<UserDto> RegisterAsync(RegisterRequest request)
    {
        User? user = ApplicationMemoryUserList.GetUserByEmail(request.Email);

        if (user != null)
            throw new AuthorizationException("Пользователь с таким email уже зарегистрирован");

        user = User.Create(request.Email);
        ApplicationMemoryUserList.Add(user);

        MailDto mail = BuildMailDto(user);

        _messageProducer.SendMessage(mail);

        await Task.CompletedTask;
        return new UserDto(user.Id, user.Email);
    }

    public async Task VerifyAsync(VerifingEmailRequest request)
    {
        await Task.Run(() => Verify(request));
    }

    private static void Verify(VerifingEmailRequest request)
    {
        User? user = ApplicationMemoryUserList.GetUserById(request.UserId);

        if (user == null)
            throw new ArgumentNullException("Пользователь не найден");

        if (user.VerificationCode != request.Code)
            throw new AuthorizationException("Неправильный код подтверждения");

        user.Verify();
    }

    private MailDto BuildMailDto(User user)
    {
        string html = BuildHtml(user.VerificationCode);

        var mail = new MailDto(_mailSettings.From, _mailSettings.Host, 
            _mailSettings.Port, _mailSettings.Login,
            _mailSettings.Password, user.Email, user.VerificationCode,
            "Регистрация в приложении", html);

        return mail;
    }

    private static string BuildHtml(int code)
    {
        string html = "<h1>Регистрация в приложении</h1>" +
            $"<h2>Код для подтверждения регистрации: {code}</h2>" +
            "<h3>Если Вы не регистрировались в приложении, проигнорируйте это письмо</h3>";

        return html;
    }
}