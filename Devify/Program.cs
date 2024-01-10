using Devify.Application.Interfaces;
using Devify.Infrastructure.Services;
using Devify.Installers;
using Devify.Middlewares;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;

namespace Devify;
public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .WriteTo.Console(theme: AnsiConsoleTheme.Code)
              .WriteTo.File("Logs/mylog.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });

        builder.Services.InstallerServicesInAssembly(builder.Configuration);
        builder.Services.AddScoped<IVnPayService, VnPayRepository>();
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseTokenMiddleware();
        app.UseExceptionHandlerMiddleware();
        app.MapControllers();

        app.Run();
    }
}


