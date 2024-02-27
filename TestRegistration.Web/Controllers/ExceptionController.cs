using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestRegistration.Web.Exceptions;

namespace TestRegistration.Web.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        switch (exception)
        {
            case AuthorizationException authorizationException:
                return Problem(title: authorizationException.Message, statusCode: (int)HttpStatusCode.Conflict);
            case ArgumentNullException argumentNullException:
                return Problem(title: argumentNullException.Message, statusCode: (int)HttpStatusCode.NotFound);
            default:
                return Problem(title: "Внутренняя ошибка сервера", statusCode: (int)HttpStatusCode.InternalServerError);
        }
    }
}