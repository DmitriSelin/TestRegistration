using Microsoft.AspNetCore.Mvc;
using TestRegistration.Web.Extensions;
using TestRegistration.Web.Models.Dto;
using TestRegistration.Web.Requests;
using TestRegistration.Web.Services.Interfaces;

namespace TestRegistration.Web.Controllers;

[ApiController]
[Route("/")]
public sealed class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrors());

        UserDto user = await _authService.RegisterAsync(request);

        return Ok(user);
    }

    [HttpPost("verify")]
    public async Task<IActionResult> VerifyAsync(VerifingEmailRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrors());

        await _authService.VerifyAsync(request);
        return Ok("Успешная регистрация");
    }
}