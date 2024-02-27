using TestRegistration.Web.Models.Dto;

namespace TestRegistration.EmailServer.Services.Interfaces;

public interface IMailService
{
    void SendMessage(MailDto mailDto);
}