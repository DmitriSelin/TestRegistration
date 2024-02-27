using TestRegistration.Web.Infrastructure;
using TestRegistration.Web.Middlewares;
using TestRegistration.Web.Services;
using TestRegistration.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IMessageProducer, MessageProducer>();
    builder.Services.AddScoped<IAuthService, AuthenticationService>();
    builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(MailSettings.SectionName));
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseMiddleware<TimeOutMiddleware>();

    app.MapControllers();
    app.Run();
}