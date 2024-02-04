using Devify.Application.Interfaces;
using Devify.Infrastructure.Services;
using Devify.Installers;
using Devify.Middlewares;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;
using Devify.Application.Configs;
using Devify.Common;

namespace Devify;
public class Program
{
    public static StatusApi my_api = new StatusApi();   
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .WriteTo.Console(theme: AnsiConsoleTheme.Code)
              .WriteTo.File("Logs/mylog.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();
        
        var builder = WebApplication.CreateBuilder(args);
        ConfigKey config = new ConfigKey(builder.Configuration);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
        //app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseTokenMiddleware();
        app.UseExceptionHandlerMiddleware();
        app.MapControllers();

        try
        {
            Thread t = new Thread(async () =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    while (true)
                    {
                        IServiceProvider services = scope.ServiceProvider;
                        IUnitOfWork unitOfWork = services.GetRequiredService<IUnitOfWork>();
                        await unitOfWork.token.DeleteRevokedToken();
                        Thread.Sleep(5 * 1000);
                    }
                }
            });
            t.Start();
        }
        catch (Exception ex)
        {
            Log.Error($"Thread remove revoked token - ex: ${ex.InnerException}");
        }

        app.Run();
    }
}


