using TestRegistration.Web.Models.Dto;
using TestRegistration.Web.Requests;

namespace TestRegistration.Web.Services.Interfaces;

public interface IAuthService
{
    public Task<UserDto> RegisterAsync(RegisterRequest request);

    public Task VerifyAsync(VerifingEmailRequest request);
}