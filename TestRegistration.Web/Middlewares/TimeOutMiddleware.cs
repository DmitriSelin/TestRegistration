namespace TestRegistration.Web.Middlewares;

public sealed class TimeOutMiddleware
{
    private readonly RequestDelegate _next;

    public TimeOutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        using (var cts = new CancellationTokenSource())
        {
           /* я знаю про более простой способ установки тайм-аута,
              но он доступен с .NET8,
              который пока не совсем стабилен */
            cts.CancelAfter(5000);

            var token = cts.Token;
            context.RequestAborted = token;

            await _next(context);
        }
    }
}